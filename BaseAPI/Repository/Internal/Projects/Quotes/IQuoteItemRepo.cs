using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Projects.Quotes;

namespace BaseAPI.Repository.Internal.Projects.Quotes
{
    public interface IQuoteItemRepo
    {
        IEnumerable<QuoteItems> getAll();
        QuoteItems getById(int id);
        bool add(QuoteItems quoteItem);
        bool update(int id, QuoteItems quoteItem);
        bool delete(int id);
    }
}
