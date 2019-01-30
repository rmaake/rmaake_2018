using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Projects.Invoices;

namespace BaseAPI.Models.Internal.Projects.Defaults
{
    public class Default
    {
        public int DefaultId { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }

        public int ProjectContentId { get; set; }
        public virtual ProjectContent ProjectContent { get; set; }
        public virtual List<InvoiceItems> InvoiceItems { get; set; }
    }
}
