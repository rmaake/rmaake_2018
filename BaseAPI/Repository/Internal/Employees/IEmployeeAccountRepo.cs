using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Employees;

namespace BaseAPI.Repository.Internal.Employees
{
    public interface IEmployeeAccountRepo
    {
        IEnumerable<EmployeeAccounts> getAll();
        EmployeeAccounts getById(int id);
        bool add(EmployeeAccounts employeeAccount);
        bool update(int id, EmployeeAccounts employeeAccounts);
        bool delete(int id);
    }
}
