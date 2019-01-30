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
    public class DefaultController : Controller
    {
        private IDefaultRepo _Default;

        public DefaultController(IDefaultRepo Default)
        {
            _Default = Default;
        }
        // GET: api/<controller>
        [HttpGet]
        [Authorize]
        //[Authorize(Roles = "Default:6, Default:5, Default:12, Default:13, Default:15, Default:16, Default:10, Default:11")]
        public IEnumerable<Default> GetAll()
        {
            return _Default.getAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "DefaultById")]
        [Authorize]
        //[Authorize(Roles = "Default:6, Default:5, Default:12, Default:13, Default:15, Default:16, Default:10, Default:11")]
        public Default GetById(int id)
        {
            return _Default.getById(id);
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize]
        //[Authorize(Roles = "Default:12, Default:13, Default:15, Default:16")]
        public IActionResult Create([FromBody] Default Default)
        {
            var res = _Default.add(Default);
            if (res == true)
                return CreatedAtRoute("DefaultById", new { Controller = "Default", id = Default.DefaultId }, Default);
            return StatusCode(500);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize]
        //[Authorize(Roles = "Default:15, Default:16, Default:10, Default:11")]
        public IActionResult Update(int id, [FromBody]Default Default)
        {
            return _Default.update(id, Default) ? new NoContentResult() : StatusCode(500);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize]
        //[Authorize(Roles = "Default:13, Default:16, Default:11, Default:6")]
        public IActionResult Delete(int id)
        {
            return _Default.delete(id) ? new NoContentResult() : StatusCode(500);
        }
    }
}
