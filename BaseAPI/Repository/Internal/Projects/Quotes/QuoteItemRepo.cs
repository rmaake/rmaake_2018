using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models;
using BaseAPI.Models.Internal.Projects.Quotes;

namespace BaseAPI.Repository.Internal.Projects.Quotes
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
            return _context.QuoteItems.ToList();
        }
        public QuoteItems getById(int id)
        {
            return _context.QuoteItems.Where(obj => obj.QuoteItemsId == id).SingleOrDefault();
        }
        public bool add(QuoteItems quoteItem)
        {
            try
            {
                _context.QuoteItems.Add(quoteItem);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            return true;
        }
        public bool update(int id, QuoteItems quoteItem)
        {
            quoteItem.QuoteItemsId = id;
            try
            {
                _context.QuoteItems.Update(quoteItem);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            return true;
        }
        public bool delete(int id)
        {
            var tmp = getById(id);
            try
            {
                _context.QuoteItems.Remove(tmp);
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
