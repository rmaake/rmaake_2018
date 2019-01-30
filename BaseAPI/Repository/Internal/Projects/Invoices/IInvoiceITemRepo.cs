using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Projects.Invoices;

namespace BaseAPI.Repository.Internal.Projects.Invoices
{
    public interface IInvoiceItemRepo
    {
        IEnumerable<InvoiceItems> getAll();
        InvoiceItems getById(int id);
        bool add(InvoiceItems invoiceItem);
        bool update(int id, InvoiceItems invoiceItem);
        bool delete(int id);
    }
}
