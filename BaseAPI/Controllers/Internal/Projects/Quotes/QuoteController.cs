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
    public class QuoteController : Controller
    {
        private IQuoteRepo _quote;

        public QuoteController(IQuoteRepo quote)
        {
            _quote = quote;
        }
        // GET: api/<controller>
        [HttpGet]
        // [Authorize(Roles = "Quote:6, Quote:5, Quote:12, Quote:13, Quote:15, Quote:16, Quote:10, Quote:11")]
        public IEnumerable<Quote> GetAll()
        {
            return _quote.getAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "QuoteById")]
        // [Authorize(Roles = "Quote:6, Quote:5, Quote:12, Quote:13, Quote:15, Quote:16, Quote:10, Quote:11")]
        public Quote GetById(int id)
        {
            return _quote.getById(id);
        }

        // POST api/<controller>
        [HttpPost]
        // [Authorize(Roles = "Quote:12, Quote:13, Quote:15, Quote:16")]
        public IActionResult Create([FromBody] Quote quote)
        {
            var res = _quote.add(quote);
            if (res == true)
                return CreatedAtRoute("QuoteById", new { Controller = "Quote", id = quote.QuoteId }, quote);
            return StatusCode(500);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        // [Authorize(Roles = "Quote:15, Quote:16, Quote:10, Quote:11")]
        public IActionResult Update(int id, [FromBody]Quote quote)
        {
            return _quote.update(id, quote) ? new NoContentResult() : StatusCode(500);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        // [Authorize(Roles = "Quote:13, Quote:16, Quote:11, Quote:6")]
        public IActionResult Delete(int id)
        {
            return _quote.delete(id) ? new NoContentResult() : StatusCode(500);
        }
    }
}
