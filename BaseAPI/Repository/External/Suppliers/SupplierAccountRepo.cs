using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models;
using BaseAPI.Models.External.Suppliers;

namespace BaseAPI.Repository.External.Suppliers
{
    public class SupplierAccountRepo : ISupplierAccountRepo
    { 
        private BaseApiContext _context;

        public SupplierAccountRepo(BaseApiContext context)
        {
            _context = context;
        }

        public IEnumerable<SupplierAccount> getAll()
        {
            return _context.ExternalSupplierAccounts.ToList();
        }
        public SupplierAccount getById(int id)
        {
            return _context.ExternalSupplierAccounts.Where(obj => obj.SupplierAccountId == id).SingleOrDefault();
        }

        public bool addSupplierAccount(SupplierAccount supplier)
        {
            try
            {
                _context.ExternalSupplierAccounts.Add(supplier);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            return true;
        }
        public bool updateSupplierAccount(int id, SupplierAccount supplier)
        {
            supplier.SupplierId = id;
            try
            {
                _context.ExternalSupplierAccounts.Update(supplier);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            return true;
        }
        public bool deleteSupplierAccount(int id)
        {
            var tmp = getById(id);
            try
            {
                _context.ExternalSupplierAccounts.Remove(tmp);
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
