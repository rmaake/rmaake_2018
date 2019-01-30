using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BaseAPI.Models.Internal.Projects.Invoices;
using BaseAPI.Repository.Internal.Projects.Invoices;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseAPI.Controllers.Internal.Projects.Invoices
{
    [Route("api/[controller]")]
    [EnableCors("AllowAnyOrigin")]
    public class InvoiceItemController : Controller
    {
        private IInvoiceItemRepo _invoiceItem;

        public InvoiceItemController(IInvoiceItemRepo invoiceItem)
        {
            _invoiceItem = invoiceItem;
        }
        // GET: api/<controller>
        [HttpGet]
        [Authorize(Roles = "InvoiceItem:6, InvoiceItem:5, InvoiceItem:12, InvoiceItem:13, InvoiceItem:15, InvoiceItem:16, InvoiceItem:10, InvoiceItem:11")]
        public IEnumerable<InvoiceItems> GetAll()
        {
            return _invoiceItem.getAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "InvoiceItemById")]
        [Authorize(Roles = "InvoiceItem:6, InvoiceItem:5, InvoiceItem:12, InvoiceItem:13, InvoiceItem:15, InvoiceItem:16, InvoiceItem:10, InvoiceItem:11")]
        public InvoiceItems GetById(int id)
        {
            return _invoiceItem.getById(id);
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Roles = "InvoiceItem:12, InvoiceItem:13, InvoiceItem:15, InvoiceItem:16")]
        public IActionResult Create([FromBody] InvoiceItems invoiceItem)
        {
            var res = _invoiceItem.add(invoiceItem);
            if (res == true)
                return CreatedAtRoute("InvoiceItemById", new { Controller = "InvoiceItem", id = invoiceItem.InvoiceItemsId }, invoiceItem);
            return StatusCode(500);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "InvoiceItem:15, InvoiceItem:16, InvoiceItem:10, InvoiceItem:11")]
        public IActionResult Update(int id, [FromBody]InvoiceItems invoiceItem)
        {
            return _invoiceItem.update(id, invoiceItem) ? new NoContentResult() : StatusCode(500);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "InvoiceItem:13, InvoiceItem:16, InvoiceItem:11, InvoiceItem:6")]
        public IActionResult Delete(int id)
        {
            return _invoiceItem.delete(id) ? new NoContentResult() : StatusCode(500);
        }
    }
}
