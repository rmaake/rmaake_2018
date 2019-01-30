using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BaseAPI.Repository.Internal.Projects.Invoices;
using BaseAPI.Models.Internal.Projects.Invoices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseAPI.Controllers.Internal.Projects.Invoices
{
    [Route("api/[controller]")]
    [EnableCors("AllowAnyOrigin")]
    public class InvoiceController : Controller
    {
        private IInvoiceRepo _invoice;

        public InvoiceController(IInvoiceRepo invoice)
        {
            _invoice = invoice;
        }
        // GET: api/<controller>
        [HttpGet]
        [Authorize(Roles = "Invoice:6, Invoice:5, Invoice:12, Invoice:13, Invoice:15, Invoice:16, Invoice:10, Invoice:11")]
        public IEnumerable<Invoice> GetAll()
        {
            return _invoice.getAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "InvoiceById")]
        [Authorize(Roles = "Invoice:6, Invoice:5, Invoice:12, Invoice:13, Invoice:15, Invoice:16, Invoice:10, Invoice:11")]
        public Invoice GetById(int id)
        {
            return _invoice.getById(id);
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Roles = "Invoice:12, Invoice:13, Invoice:15, Invoice:16")]
        public IActionResult Create([FromBody] Invoice invoice)
        {
            var res = _invoice.add(invoice);
            if (res == true)
                return CreatedAtRoute("InvoiceById", new { Controller = "Invoice", id = invoice.InvoiceId }, invoice);
            return StatusCode(500);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Invoice:15, Invoice:16, Invoice:10, Invoice:11")]
        public IActionResult Update(int id, [FromBody]Invoice invoice)
        {
            return _invoice.update(id, invoice) ? new NoContentResult() : StatusCode(500);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Invoice:13, Invoice:16, Invoice:11, Invoice:6")]
        public IActionResult Delete(int id)
        {
            return _invoice.delete(id) ? new NoContentResult() : StatusCode(500);
        }
    }
}
