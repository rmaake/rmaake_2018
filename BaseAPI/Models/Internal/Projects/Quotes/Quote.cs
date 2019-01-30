using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Clients;
namespace BaseAPI.Models.Internal.Projects.Quotes
{
    public class Quote
    {
        public int QuoteId { get; set; }
        public string Description { get; set; }

        public int ClientsId { get; set; }
        public virtual Client Client { get; set; }
        public virtual List<QuoteItems> QuoteItems { get; set; }
    }
}
