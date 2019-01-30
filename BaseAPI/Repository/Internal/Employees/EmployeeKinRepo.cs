using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Employees;
using BaseAPI.Models;

namespace BaseAPI.Repository.Internal.Employees
{
    public class EmployeeKinRepo : IEmployeeKinRepo
    {
        private BaseApiContext _context;
        public EmployeeKinRepo(BaseApiContext context)
        {
            _context = context;
        }

        public IEnumerable<EmployeeKin> getAll()
        {
            return _context.EmployeeKins.ToList();
        }
        public EmployeeKin getById(int id)
        {
            return _context.EmployeeKins.Where(obj => obj.EmployeeKinId == id).SingleOrDefault();
        }
        public bool add(EmployeeKin employeeKin)
        {
            try
            {
                _context.EmployeeKins.Add(employeeKin);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            return true;
        }
        public bool update(int id, EmployeeKin employeeKin)
        {
            employeeKin.EmployeeKinId = id;
            try
            {
                _context.EmployeeKins.Update(employeeKin);
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
                _context.EmployeeKins.Remove(tmp);
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
