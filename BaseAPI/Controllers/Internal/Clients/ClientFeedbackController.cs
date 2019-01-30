using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using BaseAPI.Repository.Internal.Clients;
using BaseAPI.Models.Internal.Clients;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseAPI.Controllers.Internal.Clients
{
    [Route("api/[controller]")]
    [EnableCors("AllowAnyOrigin")]
    public class ClientFeedbackController : Controller
    {
        private IClientFeedbackRepo _ClientFeedback;

        public ClientFeedbackController(IClientFeedbackRepo ClientFeedback)
        {
            _ClientFeedback = ClientFeedback;
        }
        // GET: api/<controller>
        [HttpGet]
        //[Authorize(Roles = "ClientFeedback:6, ClientFeedback:5, ClientFeedback:12, ClientFeedback:13, ClientFeedback:15, ClientFeedback:16, ClientFeedback:10, ClientFeedback:11")]
        public IEnumerable<ClientFeedback> GetAll()
        {
            return _ClientFeedback.getAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "ClientFeedbackById")]
        //[Authorize(Roles = "ClientFeedback:6, ClientFeedback:5, ClientFeedback:12, ClientFeedback:13, ClientFeedback:15, ClientFeedback:16, ClientFeedback:10, ClientFeedback:11")]
        public ClientFeedback GetById(int id)
        {
            return _ClientFeedback.getById(id);
        }

        // POST api/<controller>
        [HttpPost]
        //[Authorize(Roles = "ClientFeedback:12, ClientFeedback:13, ClientFeedback:15, ClientFeedback:16")]
        public IActionResult Create([FromBody] ClientFeedback ClientFeedback)
        {
            var res = _ClientFeedback.add(ClientFeedback);
            if (res == true)
                return CreatedAtRoute("ClientFeedbackById", new { Controller = "ClientFeedback", id = ClientFeedback.ClientFeedbackId }, ClientFeedback);
            return StatusCode(500);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        //[Authorize(Roles = "ClientFeedback:15, ClientFeedback:16, ClientFeedback:10, ClientFeedback:11")]
        public IActionResult Update(int id, [FromBody]ClientFeedback ClientFeedback)
        {
            return _ClientFeedback.update(id, ClientFeedback) ? new NoContentResult() : StatusCode(500);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        //[Authorize(Roles = "ClientFeedback:13, ClientFeedback:16, ClientFeedback:11, ClientFeedback:6")]
        public IActionResult Delete(int id)
        {
            return _ClientFeedback.delete(id) ? new NoContentResult() : StatusCode(500);
        }
    }
}
