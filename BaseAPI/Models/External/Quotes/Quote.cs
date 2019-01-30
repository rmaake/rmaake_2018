using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.External.Suppliers;

namespace BaseAPI.Models.External.Quotes
{
    public class Quote
    {
        public int QuoteId { get; set; }
        public string ReferenceNumber { get; set; }
        public double? Discount { get; set; }
        public DateTime Date { get; set; }

        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual List<QuoteItems> QuoteItems { get; set; }
    }
}
