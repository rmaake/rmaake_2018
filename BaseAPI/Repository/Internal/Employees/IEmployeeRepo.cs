using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Employees;
namespace BaseAPI.Repository.Internal.Employees
{
    public interface IEmployeeRepo
    {
        IEnumerable<Employee> getAll();
        Employee getById(int id);
        bool add(Employee employee);
        bool update(int id, Employee employee);
        bool delete(int id);
    }
}
