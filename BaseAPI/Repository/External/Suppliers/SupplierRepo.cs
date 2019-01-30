using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.External.Suppliers;
using BaseAPI.Models;
namespace BaseAPI.Repository.External.Suppliers
{
    public class SupplierRepo : ISupplierRepo
    {
        private BaseApiContext _context;

        public SupplierRepo(BaseApiContext context)
        {
            _context = context;
        }

        public IEnumerable<Supplier> getAll()
        {
            return _context.ExternalSuppliers.ToList();
        }
        public Supplier getById(int id)
        {
            return _context.ExternalSuppliers.Where(obj => obj.SupplierId == id).SingleOrDefault();
        }

        public bool addSupplier(Supplier supplier)
        {
            try
            {
                _context.ExternalSuppliers.Add(supplier);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            return true;
        }
        public bool updateSupplier(int id, Supplier supplier)
        {
            supplier.SupplierId = id;
            try
            {
                _context.ExternalSuppliers.Update(supplier);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            return true;
        }
        public bool deleteSupplier(int id)
        {
            var tmp = getById(id);
            try
            {
                _context.ExternalSuppliers.Remove(tmp);
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
