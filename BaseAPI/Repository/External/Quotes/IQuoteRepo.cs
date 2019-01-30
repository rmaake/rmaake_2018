using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.External.Quotes;
namespace BaseAPI.Repository.External.Quotes
{
    public interface IQuoteRepo
    {
        IEnumerable<Quote> getAll();
        Quote getById(int id);
        bool addQuote(Quote quote);
        bool updateQuote(int id, Quote quote);
        bool deleteQuote(int id);
    }
}
