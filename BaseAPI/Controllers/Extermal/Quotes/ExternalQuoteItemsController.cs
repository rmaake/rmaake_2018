using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BaseAPI.Repository.External.Quotes;
using BaseAPI.Models.External.Quotes;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseAPI.Controllers.Extermal.Quotes
{
    [Route("api/[controller]")]
    [EnableCors("AllowAnyOrigin")]
    public class ExternalQuoteItemsController : Controller
    {
        private IQuoteItemRepo _quoteItem;
        public ExternalQuoteItemsController(IQuoteItemRepo quoteItem)
        {
            _quoteItem = quoteItem;
        }
        // GET: api/<controller>
        [HttpGet]
        [Authorize(Roles = "ExternalQuoteItems:6, ExternalQuoteItems:5, ExternalQuoteItems:12, ExternalQuoteItems:13, ExternalQuoteItems:15, ExternalQuoteItems:16, ExternalQuoteItems:10, ExternalQuoteItems:11")]
        public IEnumerable<QuoteItems> GetAll()
        {
            return _quoteItem.getAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name ="ExternalQuoteItemById")]
        [Authorize(Roles = "ExternalQuoteItems:6, ExternalQuoteItems:5, ExternalQuoteItems:12, ExternalQuoteItems:13, ExternalQuoteItems:15, ExternalQuoteItems:16, ExternalQuoteItems:10, ExternalQuoteItems:11")]
        public QuoteItems GetById(int id)
        {
            if (id == 0)
                return new QuoteItems();
            return _quoteItem.getById(id);
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Roles = "ExternalQuoteItems:12, ExternalQuoteItems:13, ExternalQuoteItems:15, ExternalQuoteItems:16")]
        public IActionResult Create([FromBody]QuoteItems quoteItem)
        {
            var res = _quoteItem.addQuoteItem(quoteItem);
            if (res == true)
                return  CreatedAtRoute("ExternalQuoteItemById", new { Controller = "ExternalQuoteItems", id = quoteItem.QuoteItemsId }, quoteItem);
            return StatusCode(500);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "ExternalQuoteItems:15, ExternalQuoteItems:16, ExternalQuoteItems:10, ExternalQuoteItems:11")]
        public IActionResult Update(int id, [FromBody]QuoteItems quoteItem)
        {
            var res = _quoteItem.updateQuoteItem(id, quoteItem);

            if (res == true)
                return new NoContentResult();
            return StatusCode(500);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "ExternalQuoteItems:13, ExternalQuoteItems:16, ExternalQuoteItems:11, ExternalQuoteItems:6")]
        public IActionResult Delete(int id)
        {
            var res = _quoteItem.deleteQuoteItem(id);
            if (res == true)
                return new NoContentResult();
            return StatusCode(500);
        }
    }
}
