using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BaseAPI.Models.Internal.Employees;
using BaseAPI.Repository.Internal.Employees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseAPI.Controllers.Internal.Employees
{
    [Route("api/[controller]")]
    [EnableCors("AllowAnyOrigin")]
    public class EmployeeAccountController : Controller
    {
        private IEmployeeAccountRepo _employeeAccount;

        public EmployeeAccountController(IEmployeeAccountRepo employeeAccount)
        {
            _employeeAccount = employeeAccount;
        }
        // GET: api/<controller>
        [HttpGet]
        //[Authorize(Roles = "EmployeeAccount:6, EmployeeAccount:5, EmployeeAccount:12, EmployeeAccount:13, EmployeeAccount:15, EmployeeAccount:16, EmployeeAccount:10, EmployeeAccount:11")]
        public IEnumerable<EmployeeAccounts> GetAll()
        {
            return _employeeAccount.getAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "employeeAccountById")]
        //[Authorize(Roles = "EmployeeAccount:6, EmployeeAccount:5, EmployeeAccount:12, EmployeeAccount:13, EmployeeAccount:15, EmployeeAccount:16, EmployeeAccount:10, EmployeeAccount:11")]
        public EmployeeAccounts GetById(int id)
        {
            return _employeeAccount.getById(id);
        }

        // POST api/<controller>
        [HttpPost]
        //[Authorize(Roles = "EmployeeAccount:12, EmployeeAccount:13, EmployeeAccount:15, EmployeeAccount:16")]
        public IActionResult Create([FromBody] EmployeeAccounts employeeAccount)
        {
            var res = _employeeAccount.add(employeeAccount);
            if (res == true)
                return CreatedAtRoute("employeeAccountById", new { Controller = "employeeAccount", id = employeeAccount.EmployeeAccountsId }, employeeAccount);
            return StatusCode(500);
        }

        // PUT api/<controller>/5
        
        [HttpPut("{id}")]
        //[Authorize(Roles = "EmployeeAccount:15, EmployeeAccount:16, EmployeeAccount:10, EmployeeAccount:11")]
        public IActionResult Update(int id, [FromBody]EmployeeAccounts employeeAccount)
        {
            return _employeeAccount.update(id, employeeAccount) ? new NoContentResult() : StatusCode(500);
        }

        // DELETE api/<controller>/5
        
        [HttpDelete("{id}")]
        //[Authorize(Roles = "EmployeeAccount:13, EmployeeAccount:16, EmployeeAccount:11, EmployeeAccount:6")]
        public IActionResult Delete(int id)
        {
            return _employeeAccount.delete(id) ? new NoContentResult() : StatusCode(500);
        }
    }
}
