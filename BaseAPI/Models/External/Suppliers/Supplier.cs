using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.External.Quotes;
namespace BaseAPI.Models.External.Suppliers
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Tell { get; set; }
        public string Email { get; set; }

        public virtual List<SupplierAccount> SupplierAccounts { get; set; }
        public virtual List<Quote> Quotes { get; set; }
    }
}
