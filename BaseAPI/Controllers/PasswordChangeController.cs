using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal;
using BaseAPI.Models.Internal.Credentials;
using BaseAPI.Repository.Internal.Clients;
using BaseAPI.Repository.Internal.Employees;
using BaseAPI.Repository.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAnyOrigin")]
    public class PasswordChangeController : Controller
    {
        // GET: api/<controller>
        private IEmployeeRepo _repo;
        private IPasswordTools _tools;
        private IComMail _comMail;
        private IClientContactInfoRepo _crepo;
        public PasswordChangeController(IEmployeeRepo repo, IClientContactInfoRepo crepo, IPasswordTools tools, IComMail mail)
        {
            _repo = repo;
            _tools = tools;
            _comMail = mail;
            _crepo = crepo;
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody]PasswordChange value)
        {
            var tmp = _repo.getById(value.EmployeeId);
            if (tmp == null)
                return StatusCode(404);
            value.OldPassword = _tools.passwordHash(value.OldPassword);
            if (tmp.Password.Equals(value.OldPassword) == false)
                return StatusCode(500);
            tmp.Password = _tools.passwordHash(value.NewPassword);
            _repo.update(tmp.EmployeeId, tmp);
            return StatusCode(200);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]UserCredentials value)
        {
            if (id == 0)
                resetEmployeePassword(value.Username);
            else if (id == 1)
                resetClientPassword(value.Username);
            else
                return StatusCode(404);
            return StatusCode(200);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        private void resetClientPassword(string id)
        {
            var tmp = _crepo.getByUsername(id);
            var pwd = _tools.passwordGen(10);
            tmp.Password = _tools.passwordHash(pwd);
            var email = new ComMails();
            email.Email = new List<string>();
            email.Email.Add(tmp.Email);
            email.Message = "Please find below, your credentials to NRP Portal:<br/>Sign in as Client<br/>";
            email.Message += "Username " + tmp.Username + "<br/>Password: " + pwd;
            _comMail.SendMailToPar(email);
            _crepo.update(tmp.ClientContactInfoId, tmp);
        }
        private void resetEmployeePassword(string id)
        {
           
            var tmp = _repo.getByUsername(id);
            var pwd = _tools.passwordGen(10);
            tmp.Password = _tools.passwordHash(pwd);
            var email = new ComMails();
            email.Email = new List<string>();
            email.Email.Add(tmp.Email);
            email.Message = "Please find below, your credentials to NRP Portal:<br/>Sign in as Employee<br/>";
            email.Message += "Username " + tmp.Username + "<br/>Password: " + pwd;
            _comMail.SendMailToPar(email);
            _repo.update(tmp.EmployeeId, tmp);
        }
    }
}
