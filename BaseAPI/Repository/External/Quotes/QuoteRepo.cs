using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models;
using BaseAPI.Models.External.Quotes;
using Microsoft.EntityFrameworkCore;

namespace BaseAPI.Repository.External.Quotes
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
            return _context.ExternalQuotes.Include(c => c.QuoteItems).ToList();
            // return _context.ExternalQuotes.ToList();
        }

        public Quote getById(int id)
        {
            return _context.ExternalQuotes.Where(obj => obj.QuoteId == id).SingleOrDefault();
        }

        public bool addQuote(Quote quote)
        {
            try
            {
                _context.ExternalQuotes.Add(quote);
                _context.SaveChanges();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            return true;
        }

        public bool updateQuote(int id, Quote quote)
        {
            quote.QuoteId = id;
            try
            {
                _context.ExternalQuotes.Update(quote);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            return true;
        }

        public bool deleteQuote(int id)
        {
            var tmp = getById(id);
            try
            {
                _context.ExternalQuotes.Remove(tmp);
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
