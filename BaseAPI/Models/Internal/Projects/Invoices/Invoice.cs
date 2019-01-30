using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace BaseAPI.Models.Internal.Projects.Invoices
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public string Description { get; set; }

        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public virtual List<InvoiceItems> InvoiceItems { get; set; }
    }
}
