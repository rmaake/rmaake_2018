using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.External.Suppliers;
namespace BaseAPI.Repository.External.Suppliers
{
    public interface ISupplierRepo
    {
        IEnumerable<Supplier> getAll();
        Supplier getById(int id);
        bool addSupplier(Supplier supplier);
        bool updateSupplier(int id, Supplier supplier);
        bool deleteSupplier(int id);
    }
}
