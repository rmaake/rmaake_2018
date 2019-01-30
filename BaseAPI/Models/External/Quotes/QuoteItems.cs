using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseAPI.Models.External.Quotes
{
    public class QuoteItems
    {
        public int QuoteItemsId { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Vat { get; set; }

        public int QuoteId { get; set; }
        public virtual Quote Quote { get; set; }
    }
}
