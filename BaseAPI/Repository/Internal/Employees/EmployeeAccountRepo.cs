using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models;
using BaseAPI.Models.Internal.Employees;

namespace BaseAPI.Repository.Internal.Employees
{
    public class EmployeeAccountRepo : IEmployeeAccountRepo
    {
        private BaseApiContext _context;
        public EmployeeAccountRepo(BaseApiContext context)
        {
            _context = context;
        }

        public IEnumerable<EmployeeAccounts> getAll()
        {
            return _context.EmployeeAccounts.ToList();
        }
        public EmployeeAccounts getById(int id)
        {
            return _context.EmployeeAccounts.Where(obj => obj.EmployeeAccountsId == id).SingleOrDefault();
        }
        public bool add(EmployeeAccounts employeeAccount)
        {
            try
            {
                _context.EmployeeAccounts.Add(employeeAccount);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            return true;
        }
        public bool update(int id, EmployeeAccounts employeeAccount)
        {
            employeeAccount.EmployeeAccountsId = id;
            try
            {
                _context.EmployeeAccounts.Update(employeeAccount);
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
                _context.EmployeeAccounts.Remove(tmp);
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
