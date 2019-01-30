using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BaseAPI.Models.Internal.Projects.Defaults;
using BaseAPI.Repository.Internal.Projects.Defaults;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseAPI.Controllers.Internal.Projects.Defaults
{
    [Route("api/[controller]")]
    [EnableCors("AllowAnyOrigin")]
    public class DefaultTypeController : Controller
    {
        private IDefaultTypeRepo _DefaultType;

        public DefaultTypeController(IDefaultTypeRepo DefaultType)
        {
            _DefaultType = DefaultType;
        }
        // GET: api/<controller>
        [HttpGet]
        [Authorize(Roles = "DefaultType:6, DefaultType:5, DefaultType:12, DefaultType:13, DefaultType:15, DefaultType:16, DefaultType:10, DefaultType:11")]
        public IEnumerable<DefaultType> GetAll()
        {
            return _DefaultType.getAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "DefaultTypeById")]
        [Authorize(Roles = "DefaultType:6, DefaultType:5, DefaultType:12, DefaultType:13, DefaultType:15, DefaultType:16, DefaultType:10, DefaultType:11")]
        public DefaultType GetById(int id)
        {
            return _DefaultType.getById(id);
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Roles = "DefaultType:12, DefaultType:13, DefaultType:15, DefaultType:16")]
        public IActionResult Create([FromBody] DefaultType DefaultType)
        {
            var res = _DefaultType.add(DefaultType);
            if (res == true)
                return CreatedAtRoute("DefaultTypeById", new { Controller = "DefaultType", id = DefaultType.DefaultTypeId }, DefaultType);
            return StatusCode(500);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "DefaultType:15, DefaultType:16, DefaultType:10, DefaultType:11")]
        public IActionResult Update(int id, [FromBody]DefaultType DefaultType)
        {
            return _DefaultType.update(id, DefaultType) ? new NoContentResult() : StatusCode(500);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "DefaultType:13, DefaultType:16, DefaultType:11, DefaultType:6")]
        public IActionResult Delete(int id)
        {
            return _DefaultType.delete(id) ? new NoContentResult() : StatusCode(500);
        }
    }
}

