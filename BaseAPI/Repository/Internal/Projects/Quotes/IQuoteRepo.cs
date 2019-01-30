using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Projects.Quotes;

namespace BaseAPI.Repository.Internal.Projects.Quotes
{
    public interface IQuoteRepo
    {
        IEnumerable<Quote> getAll();
        Quote getById(int id);
        bool add(Quote quote);
        bool update(int id, Quote quote);
        bool delete(int id);
    }
}
