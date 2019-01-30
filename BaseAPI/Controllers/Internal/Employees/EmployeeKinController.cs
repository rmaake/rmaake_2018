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
    public class EmployeeKinController : Controller
    {
        private IEmployeeKinRepo _employeeKin;

        public EmployeeKinController(IEmployeeKinRepo employeeKin)
        {
            _employeeKin = employeeKin;
        }
        // GET: api/<controller>
        
        [HttpGet]
        //[Authorize(Roles = "EmployeeKin:6, EmployeeKin:5, EmployeeKin:12, EmployeeKin:13, EmployeeKin:15, EmployeeKin:16, EmployeeKin:10, EmployeeKin:11")]
        public IEnumerable<EmployeeKin> GetAll()
        {
            return _employeeKin.getAll();
        }

        // GET api/<controller>/5
        
        [HttpGet("{id}", Name = "EmployeeKinById")]
       // [Authorize(Roles = "EmployeeKin:6, EmployeeKin:5, EmployeeKin:12, EmployeeKin:13, EmployeeKin:15, EmployeeKin:16, EmployeeKin:10, EmployeeKin:11")]
        public EmployeeKin GetById(int id)
        {
            return _employeeKin.getById(id);
        }

        // POST api/<controller>
        
        [HttpPost]
        //[Authorize(Roles = "EmployeeKin:12, EmployeeKin:13, EmployeeKin:15, EmployeeKin:16")]
        public IActionResult Create([FromBody] EmployeeKin employeeKin)
        {
            var res = _employeeKin.add(employeeKin);
            if (res == true)
                return CreatedAtRoute("EmployeeKinById", new { Controller = "EmployeeKin", id = employeeKin.EmployeeKinId }, employeeKin);
            return StatusCode(500);
        }

        // PUT api/<controller>/5
        
        [HttpPut("{id}")]
        //[Authorize(Roles = "EmployeeKin:15, EmployeeKin:16, EmployeeKin:10, EmployeeKin:11")]
        public IActionResult Update(int id, [FromBody]EmployeeKin employeeKin)
        {
            return _employeeKin.update(id, employeeKin) ? new NoContentResult() : StatusCode(500);
        }

        // DELETE api/<controller>/5
       
        [HttpDelete("{id}")]
        //[Authorize(Roles = "EmployeeKin:13, EmployeeKin:16, EmployeeKin:11, EmployeeKin:6")]
        public IActionResult Delete(int id)
        {
            return _employeeKin.delete(id) ? new NoContentResult() : StatusCode(500);
        }
    }
}
