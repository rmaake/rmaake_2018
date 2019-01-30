using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseAPI.Models.Internal.Projects.Quotes
{
    public class QuoteItems
    {
        public int QuoteItemsId { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Rate { get; set; }
        public double Vat { get; set; }

        public int QuoteId { get; set; }
        public virtual Quote Quote { get; set; }
    }
}
