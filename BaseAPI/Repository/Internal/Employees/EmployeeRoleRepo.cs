using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Employees;
using BaseAPI.Models;
namespace BaseAPI.Repository.Internal.Employees
{
    public class EmployeeRoleRepo : IEmployeeRoleRepo
    {
        private BaseApiContext _context;
        public EmployeeRoleRepo(BaseApiContext context)
        {
            _context = context;
        }

        public IEnumerable<EmployeeRole> getAll()
        {
            return _context.EmployeeRoles.ToList();
        }
        public EmployeeRole getById(int id)
        {
            return _context.EmployeeRoles.Where(obj => obj.EmployeeRoleId == id).SingleOrDefault();
        }
        public bool add(EmployeeRole EmployeeRole)
        {
            try
            {
                _context.EmployeeRoles.Add(EmployeeRole);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            return true;
        }
        public bool update(int id, EmployeeRole EmployeeRole)
        {
            EmployeeRole.EmployeeRoleId = id;
            try
            {
                _context.EmployeeRoles.Update(EmployeeRole);
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
                _context.EmployeeRoles.Remove(tmp);
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
