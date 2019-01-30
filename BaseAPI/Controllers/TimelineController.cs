using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BaseAPI.Repository.Internal.Projects;
using BaseAPI.Models.Internal.Projects;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAnyOrigin")]
    public class TimelineController : Controller
    {
        private ITimelineRepo _timeline;

        public TimelineController(ITimelineRepo timeline)
        {
            _timeline = timeline;
        }
        // GET: api/<controller>
        [HttpGet]
        //[Authorize(Roles = "Timeline:6, Timeline:5, Timeline:12, Timeline:13, Timeline:15, Timeline:16, Timeline:10, Timeline:11")]
        public IEnumerable<Timeline> GetAll()
        {
            return _timeline.getAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "TimelineById")]
        //[Authorize(Roles = "Timeline:6, Timeline:5, Timeline:12, Timeline:13, Timeline:15, Timeline:16, Timeline:10, Timeline:11")]
        public Timeline GetById(int id)
        {
            return _timeline.getById(id);
        }

        // POST api/<controller>
        [HttpPost]
//[Authorize(Roles = "Timeline:12, Timeline:13, Timeline:15, Timeline:16")]
        public IActionResult Create([FromBody] Timeline timeline)
        {
            var res = _timeline.add(timeline);
            if (res == true)
                return CreatedAtRoute("TimelineById", new { Controller = "Timeline", id = timeline.TimelineId }, timeline);
            return StatusCode(500);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        //[Authorize(Roles = "Timeline:15, Timeline:16, Timeline:10, Timeline:11")]
        public IActionResult Update(int id, [FromBody]Timeline timeline)
        {
            return _timeline.update(id, timeline) ? new NoContentResult() : StatusCode(500);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        //[Authorize(Roles = "Timeline:13, Timeline:16, Timeline:11, Timeline:6")]
        public IActionResult Delete(int id)
        {
            return _timeline.delete(id) ? new NoContentResult() : StatusCode(500);
        }
    }
}
