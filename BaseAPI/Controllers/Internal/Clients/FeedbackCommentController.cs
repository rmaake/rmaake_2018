using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BaseAPI.Models.Internal.Clients;
using BaseAPI.Repository.Internal.Clients;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseAPI.Controllers.Internal.Clients
{
    [Route("api/[controller]")]
    [EnableCors("AllowAnyOrigin")]
    public class FeedbackCommentController : Controller
    {
        private IFeedbackCommentRepo _FeedbackComment;

        public FeedbackCommentController(IFeedbackCommentRepo FeedbackComment)
        {
            _FeedbackComment = FeedbackComment;
        }
        // GET: api/<controller>
        [HttpGet]
        [Authorize]
        //[Authorize(Roles = "FeedbackComment:6, FeedbackComment:5, FeedbackComment:12, FeedbackComment:13, FeedbackComment:15, FeedbackComment:16, FeedbackComment:10, FeedbackComment:11")]
        public IEnumerable<FeedbackComment> GetAll()
        {
            return _FeedbackComment.getAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "FeedbackCommentById")]
        [Authorize]
        //[Authorize(Roles = "FeedbackComment:6, FeedbackComment:5, FeedbackComment:12, FeedbackComment:13, FeedbackComment:15, FeedbackComment:16, FeedbackComment:10, FeedbackComment:11")]
        public FeedbackComment GetById(int id)
        {
            return _FeedbackComment.getById(id);
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize]
        //[Authorize(Roles = "FeedbackComment:12, FeedbackComment:13, FeedbackComment:15, FeedbackComment:16")]
        public IActionResult Create([FromBody] FeedbackComment FeedbackComment)
        {
            var res = _FeedbackComment.add(FeedbackComment);
            if (res == true)
                return CreatedAtRoute("FeedbackCommentById", new { Controller = "FeedbackComment", id = FeedbackComment.FeedbackCommentId }, FeedbackComment);
            return StatusCode(500);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize]
        //[Authorize(Roles = "FeedbackComment:15, FeedbackComment:16, FeedbackComment:10, FeedbackComment:11")]
        public IActionResult Update(int id, [FromBody]FeedbackComment FeedbackComment)
        {
            return _FeedbackComment.update(id, FeedbackComment) ? new NoContentResult() : StatusCode(500);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize]
        //[Authorize(Roles = "FeedbackComment:13, FeedbackComment:16, FeedbackComment:11, FeedbackComment:6")]
        public IActionResult Delete(int id)
        {
            return _FeedbackComment.delete(id) ? new NoContentResult() : StatusCode(500);
        }
    }
}
