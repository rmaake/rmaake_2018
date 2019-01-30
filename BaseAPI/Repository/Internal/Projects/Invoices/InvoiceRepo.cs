using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Projects.Invoices;
using BaseAPI.Models;

namespace BaseAPI.Repository.Internal.Projects.Invoices
{
    public class InvoiceRepo : IInvoiceRepo
    {
        private BaseApiContext _context;
        public InvoiceRepo(BaseApiContext context)
        {
            _context = context;
        }

        public IEnumerable<Invoice> getAll()
        {
            return _context.Invoices.ToList();
        }
        public Invoice getById(int id)
        {
            return _context.Invoices.Where(obj => obj.InvoiceId == id).SingleOrDefault();
        }
        public bool add(Invoice invoice)
        {
            try
            {
                _context.Invoices.Add(invoice);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            return true;
        }
        public bool update(int id, Invoice invoice)
        {
            invoice.InvoiceId = id;
            try
            {
                _context.Invoices.Update(invoice);
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
                _context.Invoices.Remove(tmp);
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
