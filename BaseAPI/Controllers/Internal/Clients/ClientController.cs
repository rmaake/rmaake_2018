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
    public class ClientController : Controller
    {
        private IClientRepo _client;

        public ClientController(IClientRepo client)
        {
            _client = client;
        }
        // GET: api/<controller>
        [HttpGet]
        // [Authorize(Roles = "Client:6, Client:5, Client:12, Client:13, Client:15, Client:16, Client:10, Client:11")]
        public IEnumerable<Client> GetAll()
        {
            return _client.getAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "ClientById")]
        // [Authorize(Roles = "Client:6, Client:5, Client:12, Client:13, Client:15, Client:16, Client:10, Client:11")]
        public Client GetById(int id)
        {
            return _client.getById(id);
        }

        // POST api/<controller>
        [HttpPost]
        // [Authorize(Roles = "Client:12, Client:13, Client:15, Client:16")]
        public IActionResult Create([FromBody] Client client)
        {
            var res = _client.add(client);
            if (res == true)
                return CreatedAtRoute("ClientById", new { Controller = "Client", id = client.ClientId }, client);
            return StatusCode(500);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        // [Authorize(Roles = "Client:15, Client:16, Client:10, Client:11")]
        public IActionResult Update(int id, [FromBody]Client client)
        {
            return _client.update(id, client) ? new NoContentResult() : StatusCode(500);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        // [Authorize(Roles = "Client:13, Client:16, Client:11, Client:6")]
        public IActionResult Delete(int id)
        {
            return _client.delete(id) ? new NoContentResult() : StatusCode(500);
        }
    }
}
