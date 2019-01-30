using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using BaseAPI.Models;
using BaseAPI.Models.Internal;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseAPI.Controllers.Internal
{
    [Route("api/[controller]")]
    [EnableCors("AllowAnyOrigin")]
    [Authorize]
    public class EmployeeTimelineController : Controller
    {
        private BaseApiContext _context;
        public EmployeeTimelineController(BaseApiContext context)
        {
            _context = context;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<EmployeeTimeline> Get()
        {
            return _context.EmployeeTimeline.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "EmployeeTimelineById")]
        public EmployeeTimeline Get(int id)
        {
            return _context.EmployeeTimeline.Where(opt => opt.EmployeeTimelineId == id).SingleOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]EmployeeTimeline value)
        {
            value.Date = DateTime.Now;
            _context.EmployeeTimeline.Add(value);
            _context.SaveChanges();
            return CreatedAtRoute("EmployeeTimelineById", new { Controller = "EmployeeTimeline", id = value.EmployeeTimelineId }, value);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]EmployeeTimeline value)
        {
            _context.EmployeeTimeline.Update(value);
            _context.SaveChanges();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _context.EmployeeTimeline.Remove(this.Get(id));
            _context.SaveChanges();
        }
    }
}
