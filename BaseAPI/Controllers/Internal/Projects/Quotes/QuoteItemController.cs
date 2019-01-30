using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BaseAPI.Models.Internal.Projects.Quotes;
using BaseAPI.Repository.Internal.Projects.Quotes;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseAPI.Controllers.Internal.Projects.Quotes
{
    [Route("api/[controller]")]
    [EnableCors("AllowAnyOrigin")]
    public class QuoteItemController : Controller
    {
        private IQuoteItemRepo _quoteItem;

        public QuoteItemController(IQuoteItemRepo quoteItem)
        {
            _quoteItem = quoteItem;
        }
        // GET: api/<controller>
        [HttpGet]
        // [Authorize(Roles = "QuoteItem:6, QuoteItem:5, QuoteItem:12, QuoteItem:13, QuoteItem:15, QuoteItem:16, QuoteItem:10, QuoteItem:11")]
        public IEnumerable<QuoteItems> GetAll()
        {
            return _quoteItem.getAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "QuoteItemById")]
        // [Authorize(Roles = "QuoteItem:6, QuoteItem:5, QuoteItem:12, QuoteItem:13, QuoteItem:15, QuoteItem:16, QuoteItem:10, QuoteItem:11")]
        public QuoteItems GetById(int id)
        {
            return _quoteItem.getById(id);
        }

        // POST api/<controller>
        [HttpPost]
        // [Authorize(Roles = "QuoteItem:12, QuoteItem:13, QuoteItem:15, QuoteItem:16")]
        public IActionResult Create([FromBody] QuoteItems quoteItem)
        {
            var res = _quoteItem.add(quoteItem);
            if (res == true)
                return CreatedAtRoute("QuoteItemById", new { Controller = "QuoteItem", id = quoteItem.QuoteItemsId }, quoteItem);
            return StatusCode(500);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        // [Authorize(Roles = "QuoteItem:15, QuoteItem:16, QuoteItem:10, QuoteItem:11")]
        public IActionResult Update(int id, [FromBody]QuoteItems quoteItem)
        {
            return _quoteItem.update(id, quoteItem) ? new NoContentResult() : StatusCode(500);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        // [Authorize(Roles = "QuoteItem:13, QuoteItem:16, QuoteItem:11, QuoteItem:6")]
        public IActionResult Delete(int id)
        {
            return _quoteItem.delete(id) ? new NoContentResult() : StatusCode(500);
        }
    }
}
