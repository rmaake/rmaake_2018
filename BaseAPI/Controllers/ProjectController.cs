using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BaseAPI.Models.Internal.Projects;
using BaseAPI.Repository.Internal.Projects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAnyOrigin")]
    public class ProjectController : Controller
    {
        private IProjectRepo _project;

        public ProjectController(IProjectRepo project)
        {
            _project = project;
        }
        // GET: api/<controller>
        [HttpGet]
        //[Authorize(Roles = "Project:6, Project:5, Project:12, Project:13, Project:15, Project:16, Project:10, Project:11")]
        public IEnumerable<Project> GetAll()
        {
            return _project.getAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "ProjectById")]
        //[Authorize(Roles = "Project:6, Project:5, Project:12, Project:13, Project:15, Project:16, Project:10, Project:11")]
        public Project GetById(int id)
        {
            return _project.getById(id);
        }

        // POST api/<controller>
        [HttpPost]
       // [Authorize(Roles = "Project:12, Project:13, Project:15, Project:16")]
        public IActionResult Create([FromBody] Project project)
        {
            var res = _project.add(project);
            if (res == true)
                return CreatedAtRoute("ProjectById", new { Controller = "Project", id = project.ProjectId }, project);
            return StatusCode(500);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        //[Authorize(Roles = "Project:15, Project:16, Project:10, Project:11")]
        public IActionResult Update(int id, [FromBody]Project project)
        {
            return _project.update(id, project) ? new NoContentResult() : StatusCode(500);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        //[Authorize(Roles = "Project:13, Project:16, Project:11, Project:6")]
        public IActionResult Delete(int id)
        {
            return _project.delete(id) ? new NoContentResult() : StatusCode(500);
        }
    }
}

