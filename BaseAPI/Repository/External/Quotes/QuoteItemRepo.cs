using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.External.Quotes;
using BaseAPI.Models;
namespace BaseAPI.Repository.External.Quotes
{
    public class QuoteItemRepo : IQuoteItemRepo
    {
        private BaseApiContext _context;

        public QuoteItemRepo(BaseApiContext context)
        {
            _context = context;
        }
        public IEnumerable<QuoteItems> getAll()
        {
            return _context.ExternalQuoteItems.ToList();
        }
        public QuoteItems getById(int id)
        {
            return _context.ExternalQuoteItems.Where(obj => obj.QuoteItemsId == id).SingleOrDefault();
        }
        public bool addQuoteItem(QuoteItems quote)
        {
            try
            {
                _context.ExternalQuoteItems.Add(quote);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
                return false;
            }
            return true;
        }
        public bool updateQuoteItem(int id, QuoteItems quote)
        {
            quote.QuoteItemsId = id;
            try
            {
                _context.ExternalQuoteItems.Update(quote);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            return true;
        }
        public bool deleteQuoteItem(int id)
        {
            var tmp = getById(id);
            try
            {
                _context.ExternalQuoteItems.Remove(tmp);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            
            return true;
        }
    }
}
