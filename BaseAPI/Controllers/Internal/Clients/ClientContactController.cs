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
    public class ClientContactController : Controller
    {
        private IClientContactInfoRepo _clientContact;

        public ClientContactController(IClientContactInfoRepo clientContact)
        {
            _clientContact = clientContact;
        }
        // GET: api/<controller>
        [HttpGet]
        [Authorize]
        //[Authorize(Roles = "ClientContact:6, ClientContact:5, ClientContact:12, ClientContact:13, ClientContact:15, ClientContact:16, ClientContact:10, ClientContact:11")]
        public IEnumerable<ClientContactInfo> GetAll()
        {
            return _clientContact.getAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "ClientContactById")]
        [Authorize]
        //[Authorize(Roles = "ClientContact:6, ClientContact:5, ClientContact:12, ClientContact:13, ClientContact:15, ClientContact:16, ClientContact:10, ClientContact:11")]
        public ClientContactInfo GetById(int id)
        {
            return _clientContact.getById(id);
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize]
        //[Authorize(Roles = "ClientContact:12, ClientContact:13, ClientContact:15, ClientContact:16")]
        public IActionResult Create([FromBody] ClientContactInfo clientContact)
        {
            var res = _clientContact.add(clientContact);
            if (res == true)
                return CreatedAtRoute("ClientContactById", new { Controller = "ClientContact", id = clientContact.ClientContactInfoId }, clientContact);
            return StatusCode(500);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize]
        //[Authorize(Roles = "ClientContact:15, ClientContact:16, ClientContact:10, ClientContact:11")]
        public IActionResult Update(int id, [FromBody]ClientContactInfo clientContact)
        {
            return _clientContact.update(id, clientContact) ? new NoContentResult() : StatusCode(500);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize]
        //[Authorize(Roles = "ClientContact:13, ClientContact:16, ClientContact:11, ClientContact:6")]
        public IActionResult Delete(int id)
        {
            return _clientContact.delete(id) ? new NoContentResult() : StatusCode(500);
        }
    }
}
