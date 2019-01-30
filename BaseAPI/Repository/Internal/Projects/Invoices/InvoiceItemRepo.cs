using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Projects.Invoices;
using BaseAPI.Models;

namespace BaseAPI.Repository.Internal.Projects.Invoices
{
    public class InvoiceItemRepo : IInvoiceItemRepo
    {
        private BaseApiContext _context;
        public InvoiceItemRepo(BaseApiContext context)
        {
            _context = context;
        }

        public IEnumerable<InvoiceItems> getAll()
        {
            return _context.InvoiceItems.ToList();
        }
        public InvoiceItems getById(int id)
        {
            return _context.InvoiceItems.Where(obj => obj.InvoiceItemsId == id).SingleOrDefault();
        }
        public bool add(InvoiceItems invoiceItem)
        {
            try
            {
                _context.InvoiceItems.Add(invoiceItem);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            return true;
        }
        public bool update(int id, InvoiceItems invoiceItem)
        {
            invoiceItem.InvoiceItemsId = id;
            try
            {
                _context.InvoiceItems.Update(invoiceItem);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            return true;
        }
        public bool delete(int id)
        {
            var tmp = getById(id);
            try
            {
                _context.InvoiceItems.Remove(tmp);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            return true;
        }
    }
}
