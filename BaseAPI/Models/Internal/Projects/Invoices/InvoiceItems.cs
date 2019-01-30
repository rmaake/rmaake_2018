using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Projects.Defaults;

namespace BaseAPI.Models.Internal.Projects.Invoices
{
    public class InvoiceItems
    {
        public int InvoiceItemsId { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Rate { get; set; }
        public double Vat { get; set; }

        public int InvoiceId { get; set; }
        public int? DefaultId { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual Default Default { get; set; }
    }
}
