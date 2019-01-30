using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BaseAPI.Models.Internal.Credentials;
using BaseAPI.Models.Internal.Clients;
using BaseAPI.Models.Internal.Employees;
using BaseAPI.Repository.Tools;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseAPI.Controllers
{

    /*
     * C = 7
     * R = 5
     * U = 3
     * D = 1
     */
    [Route("api/[controller]")]
    [EnableCors("AllowAnyOrigin")]
    public class AuthenticationController : Controller
    {
        private IAuthorizeRepo _authorize;
        public AuthenticationController(IAuthorizeRepo authorizeRepo)
        {
            _authorize = authorizeRepo;
        }
        // GET: api/<controller>
        [HttpGet]
        [Authorize]
        public Employee Get()
        {
            var cid = HttpContext.Request.Cookies.Where(opt => opt.Key == "ID").SingleOrDefault();
            return _authorize.getEmployee(Int32.Parse(cid.Value));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public UserCredentials Get(int id)
        {
            if (id == 0)
            {
                var tmp = new UserCredentials();
                //tmp.Password = "Password";
                //tmp.Username = "Username";
                return tmp;
            }
            return new UserCredentials();
        }

        // POST api/<controller>
        [HttpPost]
        public Employee Post([FromBody]UserCredentials employee)
        {
            var tmp = _authorize.employeeLogin(employee);
            if (tmp != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, tmp.Username),
                    new Claim(ClaimTypes.Hash, tmp.Password),
                    new Claim("ID",  tmp.EmployeeId.ToString())
                };
                var values = tmp.AccessCode.Split(".");
                for(int i = 0; i < values.Length; i++)
                    claims.Add(new Claim(ClaimTypes.Role, values[i]));

                var userIdentity = new ClaimsIdentity(claims, tmp.Username);

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                HttpContext.SignInAsync(principal);

                //Just redirect to our index after logging in. 
                return tmp;
            }
            return tmp;
        }
        [HttpPost("{id}")]
        public ClientContactInfo ClientLogin(int id, [FromBody]UserCredentials client)
        {
            var tmp = _authorize.clientLogin(client);
            if (tmp != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, tmp.Username),
                    new Claim(ClaimTypes.Hash, tmp.Password)

                };
                /*var values = tmp.AccessCode.Split(".");
                for (int i = 0; i < values.Length; i++)
                    claims.Add(new Claim(ClaimTypes.Role, values[i]));*/
                var userIdentity = new ClaimsIdentity(claims, tmp.Username);

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                HttpContext.SignInAsync(principal);

                //Just redirect to our index after logging in. 
                return tmp;
            }
            return tmp;
        }
        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public void Delete()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
