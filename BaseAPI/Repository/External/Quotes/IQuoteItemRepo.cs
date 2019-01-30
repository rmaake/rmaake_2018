using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.External.Quotes;
namespace BaseAPI.Repository.External.Quotes
{
    public interface IQuoteItemRepo
    {
        IEnumerable<QuoteItems> getAll();
        QuoteItems getById(int id);
        bool addQuoteItem(QuoteItems quote);
        bool updateQuoteItem(int id, QuoteItems quote);
        bool deleteQuoteItem(int id);
    }
}
