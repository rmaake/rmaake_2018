using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.External.Suppliers;

namespace BaseAPI.Repository.External.Suppliers
{
    public interface ISupplierAccountRepo
    {
        IEnumerable<SupplierAccount> getAll();
        SupplierAccount getById(int id);
        bool addSupplierAccount(SupplierAccount supplierAccount);
        bool updateSupplierAccount(int id,SupplierAccount supplierAccount);
        bool deleteSupplierAccount(int id);
    }
}
