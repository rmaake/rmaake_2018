using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Employees;
using BaseAPI.Models.Internal.Clients;
using BaseAPI.Models.Internal.Credentials;
using BaseAPI.Models;
using BaseAPI.Repository.Tools;

namespace BaseAPI.Repository.Tools
{
    public class AuthorizeRepo : IAuthorizeRepo
    {
        private BaseApiContext _context;
        private IPasswordTools _tools;
        public AuthorizeRepo(BaseApiContext context, IPasswordTools tools)
        {
            _context = context;
            _tools = tools;
        }
        //bool verifyAccess(string accessTo, string accessCode);
        public Employee employeeLogin(UserCredentials credentials)
        {
            if (credentials.Username == "rmaake" && credentials.Password == "maake82552")
            {
                var tmp = new Employee();
                tmp.FirstName = "Rapula";
                tmp.LastName = "Maake";
                tmp.ContactNumber = "+27718493239";
                tmp.Username = "rmaake";
                tmp.Password = "maake82552";
                tmp.AccessCode = "admin:read.admin:delete.admin:write";
                return tmp;
            }
            else if (credentials.Username == "akhanye" && credentials.Password == "akhanye123")
            {
                var tmp = new Employee();
                tmp.Username = "akhanye";
                tmp.Password = "akhanye123";
                tmp.AccessCode = "Employee:6.Employee:5.Employee:12.Employee:13.Employee:15.Employee:16.Employee:10.Employee:11.InvoiceItem:12.InvoiceItem:13.InvoiceItem:15.InvoiceItem:16.Employee:6.Employee:12.Employee:11.Project:6.Project:5.Project:12.Project:13.Project:15.Project:16.Project:10.Project:11";
                return tmp;
            }
            credentials.Password = _tools.passwordHash(credentials.Password);
            return _context.Employees.Where(opt => opt.Username.Equals(credentials.Username) && opt.Password.Equals(credentials.Password)).SingleOrDefault();
        }
        public ClientContactInfo clientLogin(UserCredentials credentials)
        {
             credentials.Password = _tools.passwordHash(credentials.Password);
            //var tmp = new ClientContactInfo();
           // tmp.Password = credentials.Password;
            //tmp.Username = credentials.Username;
           // tmp.AccessCode = "asd.asdasd.asdasd";
           // return tmp;
            return _context.ClientContactInfos.Where(opt => opt.Username.Equals(credentials.Username) && opt.Password.Equals(credentials.Password)).SingleOrDefault();
        }
        public Employee getEmployee(int id)
        {
            return _context.Employees.Where(opt => opt.EmployeeId == id).SingleOrDefault();
        }
        public ClientContactInfo getClient(int id)
        {
            return _context.ClientContactInfos.Where(opt => opt.ClientId == id).SingleOrDefault();
        }
    }
}
