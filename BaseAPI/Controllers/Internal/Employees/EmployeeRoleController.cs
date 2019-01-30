using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BaseAPI.Repository.Internal.Employees;
using BaseAPI.Models.Internal.Employees;
using Microsoft.AspNetCore.Cors;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseAPI.Controllers.Internal.Employees
{
    [Route("api/[controller]")]
    [EnableCors("AllowAnyOrigin")]
    public class EmployeeRoleController : Controller
    {
        private IEmployeeRoleRepo _EmployeeRole;

        public EmployeeRoleController(IEmployeeRoleRepo EmployeeRole)
        {
            _EmployeeRole = EmployeeRole;
        }
        // GET: api/<controller>
        [HttpGet]
        //[Authorize(Roles = "EmployeeRole:6, EmployeeRole:5, EmployeeRole:12, EmployeeRole:13, EmployeeRole:15, EmployeeRole:16, EmployeeRole:10, EmployeeRole:11")]
        public IEnumerable<EmployeeRole> GetAll()
        {
            return _EmployeeRole.getAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "EmployeeRoleById")]
        //[Authorize(Roles = "EmployeeRole:6, EmployeeRole:5, EmployeeRole:12, EmployeeRole:13, EmployeeRole:15, EmployeeRole:16, EmployeeRole:10, EmployeeRole:11")]
        public EmployeeRole GetById(int id)
        {
            return _EmployeeRole.getById(id);
        }

        // POST api/<controller>
        [HttpPost]
        //[Authorize(Roles = "EmployeeRole:12, EmployeeRole:13, EmployeeRole:15, EmployeeRole:16")]
        public IActionResult Create([FromBody] EmployeeRole EmployeeRole)
        {
            var res = _EmployeeRole.add(EmployeeRole);
            if (res == true)
                return CreatedAtRoute("EmployeeRoleById", new { Controller = "EmployeeRole", id = EmployeeRole.EmployeeRoleId }, EmployeeRole);
            return StatusCode(500);
        }

        // PUT api/<controller>/5

        [HttpPut("{id}")]
        //[Authorize(Roles = "EmployeeRole:15, EmployeeRole:16, EmployeeRole:10, EmployeeRole:11")]
        public IActionResult Update(int id, [FromBody]EmployeeRole EmployeeRole)
        {
            return _EmployeeRole.update(id, EmployeeRole) ? new NoContentResult() : StatusCode(500);
        }

        // DELETE api/<controller>/5

        [HttpDelete("{id}")]
        //[Authorize(Roles = "EmployeeRole:13, EmployeeRole:16, EmployeeRole:11, EmployeeRole:6")]
        public IActionResult Delete(int id)
        {
            return _EmployeeRole.delete(id) ? new NoContentResult() : StatusCode(500);
        }
    }
}
