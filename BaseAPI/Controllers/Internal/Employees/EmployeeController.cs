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
    public class EmployeeController : Controller
    {
        private IEmployeeRepo _employee;

        public EmployeeController(IEmployeeRepo employee)
        {
            _employee = employee;
        }
        // GET: api/<controller>
        
        [HttpGet]
        [Authorize]
        public IEnumerable<Employee> GetAll()
        {
            return _employee.getAll();
        }

        // GET api/<controller>/5
        
        [HttpGet("{id}", Name = "EmployeeById")]
        [Authorize]
        // [Authorize(Roles = "Employee:6, Employee:5, Employee:12, Employee:13, Employee:15, Employee:16, Employee:10, Employee:11")]
        public Employee GetById(int id)
        {
            return _employee.getById(id);
        }

        // POST api/<controller>
        
        [HttpPost]
        [Authorize]
        // [Authorize(Roles = "Employee:12, Employee:13, Employee:15, Employee:16")]
        public IActionResult Create([FromBody] Employee employee)
        {
            var res = _employee.add(employee);
            if (res == true)
                return CreatedAtRoute("EmployeeById", new { Controller = "Employee", id = employee.EmployeeId }, employee);
            return StatusCode(500);
        }

        // PUT api/<controller>/5
      
        [HttpPut("{id}")]
        [Authorize]
        // [Authorize(Roles = "Employee:15, Employee:16, Employee:10, Employee:11")]
        public IActionResult Update(int id, [FromBody]Employee employee)
        {
            return _employee.update(id, employee) ? new NoContentResult() : StatusCode(500);
        }

        // DELETE api/<controller>/5
        
        [HttpDelete("{id}")]
        [Authorize]
        // [Authorize(Roles = "Employee:13, Employee:16, Employee:11, Employee:6")]
        public IActionResult Delete(int id)
        {
            return _employee.delete(id) ? new NoContentResult() : StatusCode(500);
        }
    }
}
