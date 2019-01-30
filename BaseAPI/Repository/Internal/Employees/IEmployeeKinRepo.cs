using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Employees;

namespace BaseAPI.Repository.Internal.Employees
{
    public interface IEmployeeKinRepo
    {
        IEnumerable<EmployeeKin> getAll();
        EmployeeKin getById(int id);
        bool add(EmployeeKin employeeKin);
        bool update(int id, EmployeeKin employeeKin);
        bool delete(int id);
    }
}
