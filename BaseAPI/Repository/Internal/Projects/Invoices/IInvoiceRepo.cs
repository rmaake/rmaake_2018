using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Projects.Invoices;

namespace BaseAPI.Repository.Internal.Projects.Invoices
{
    public interface IInvoiceRepo
    {
        IEnumerable<Invoice> getAll();
        Invoice getById(int id);
        bool add(Invoice invoice);
        bool update(int id, Invoice invoice);
        bool delete(int id);
    }
}
