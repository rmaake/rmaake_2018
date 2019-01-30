using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BaseAPI.Repository.Internal.Projects;
using BaseAPI.Models.Internal.Projects;
using Microsoft.AspNetCore.Cors;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseAPI.Controllers.Internal.Projects
{
    [Route("api/[controller]")]
    [EnableCors("AllowAnyOrigin")]
    public class ProjectFileController : Controller
    {
        private IProjectFileRepo _repo;
        public ProjectFileController(IProjectFileRepo repo)
        {
            _repo = repo;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<ProjectFile> Get()
        {
            return _repo.getAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "ProjectFileById")]
        public ProjectFile Get(int id)
        {
            return _repo.getById(id);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]ProjectFile value)
        {
            var res = _repo.add(value);
            if (res == true)
                return CreatedAtRoute("ProjectFileById", new { Controller = "ProjectFile", id = value.ProjectFileId }, value);
            return StatusCode(500);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ProjectFile value)
        {
            return _repo.update(id, value) ? new NoContentResult() : StatusCode(500);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return _repo.delete(id) ? new NoContentResult() : StatusCode(500);
        }
    }
}
