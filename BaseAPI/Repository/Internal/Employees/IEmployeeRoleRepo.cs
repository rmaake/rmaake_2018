using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Employees;
namespace BaseAPI.Repository.Internal.Employees
{
    public interface IEmployeeRoleRepo
    {
        IEnumerable<EmployeeRole> getAll();
        EmployeeRole getById(int id);
        bool add(EmployeeRole employee);
        bool update(int id, EmployeeRole employee);
        bool delete(int id);
    }
}
