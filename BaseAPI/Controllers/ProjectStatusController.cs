using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BaseAPI.Models;
using BaseAPI.Models.Internal.Projects;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAnyOrigin")]
    //[Authorize]
    public class ProjectStatusController : Controller
    {
        private BaseApiContext _context;
        public ProjectStatusController(BaseApiContext context)
        {
            _context = context;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<ProjectStatus> Get()
        {
            return _context.ProjectStatuses.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "ProjectStatusById")]
        public ProjectStatus Get(int id)
        {
            return _context.ProjectStatuses.Where(opt => opt.ProjectStatusId == id).SingleOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]ProjectStatus status)
        {
            _context.ProjectStatuses.Add(status);
            _context.SaveChanges();
            return CreatedAtRoute("ProjectStatusById", new { Controller = "ProjectStatus", id = status.ProjectStatusId }, status);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]ProjectStatus status)
        {
            _context.ProjectStatuses.Update(status);
            _context.SaveChanges();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _context.ProjectStatuses.Remove(this.Get(id));
            _context.SaveChanges();
        }
    }
}
