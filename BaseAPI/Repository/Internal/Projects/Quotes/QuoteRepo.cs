using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models;
using BaseAPI.Models.Internal.Projects.Quotes;

namespace BaseAPI.Repository.Internal.Projects.Quotes
{
    public class QuoteRepo : IQuoteRepo
    {
        private BaseApiContext _context;
        public QuoteRepo(BaseApiContext context)
        {
            _context = context;
        }

        public IEnumerable<Quote> getAll()
        {
            return _context.Quotes.ToList();
        }
        public Quote getById(int id)
        {
            return _context.Quotes.Where(obj => obj.QuoteId == id).SingleOrDefault();
        }
        public bool add(Quote quote)
        {
            try
            {
                _context.Quotes.Add(quote);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            return true;
        }
        public bool update(int id, Quote quote)
        {
            quote.QuoteId = id;
            try
            {
                _context.Quotes.Update(quote);
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
                _context.Quotes.Remove(tmp);
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
