using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Employees;
using BaseAPI.Models;
using BaseAPI.Repository.Tools;
using BaseAPI.Models.Internal;
//using Microsoft.EntityFrameworkCore;

namespace BaseAPI.Repository.Internal.Employees
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private BaseApiContext _context;
        private IComMail _comMail;
        private IPasswordTools _passwordTools;
        public EmployeeRepo(BaseApiContext context, IComMail comMail, IPasswordTools passwordTools)
        {
            _context = context;
            _comMail = comMail;
            _passwordTools = passwordTools;
        }

        public IEnumerable<Employee> getAll()
        {
           
            return _context.Employees.ToList();
        }
        public Employee getById(int id)
        {
            return _context.Employees.Where(obj => obj.EmployeeId == id).SingleOrDefault();
        }
        public Employee getByUsername(string username)
        {
            try
            {
                return _context.Employees.Where(obj => obj.Username.Equals(username) == true).SingleOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return new Employee();
            }
        }
        public bool add(Employee employee)
        {
            var tmp = new ComMails();
            var rnd = new Random();
            var pwd = _passwordTools.passwordGen(10);
            employee.Username = employee.FirstName[0] + employee.LastName + rnd.Next(employee.LastName.Length * 1000).ToString();
            employee.Password = _passwordTools.passwordHash(pwd);
            tmp.Email = new List<string>();
            tmp.Email.Add(employee.Email);
            tmp.Message = "Please find below, your credentials to NRP Portal:<br/>Sign in as Employee<br/>";
            tmp.Message += "Username " + employee.Username + "<br/>Password: " + pwd;
            _comMail.SendMailToPar(tmp);
            try
            {
                
                _context.Employees.Add(employee);
                _context.SaveChanges();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            return true;
        }
        public bool update(int id, Employee employee)
        {
            employee.EmployeeId = id;
            try
            {
                _context.Employees.Update(employee);
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
                _context.Employees.Remove(tmp);
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
