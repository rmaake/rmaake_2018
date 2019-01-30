using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseAPI.Models.External.Suppliers
{
    public class SupplierAccount
    {
        public int SupplierAccountId { get; set; }
        public string ReferenceNumber { get; set; }
        public string BankName { get; set; }
        public string BankAccount { get; set; }
        public string BranchCode { get; set; }

        public int SupplierId { get; set; }
        public virtual Supplier supplier { get; set; }
    }
}
