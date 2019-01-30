using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BaseAPI.Models.External.Quotes;
using BaseAPI.Repository.External.Quotes;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseAPI.Controllers.Test
{
    [Route("api/[controller]")]
    public class TestValuesController : ControllerBase
    {
        // private IQuoteRepo _quote;
        // public ExternalQuotesController(IQuoteRepo quote)
        // {
        //     _quote = quote;
        // }
        // GET: api/<controller>
        [HttpGet]
        // [Authorize(Roles = "ExternalQuotes:6, ExternalQuotes:5, ExternalQuotes:12, ExternalQuotes:13, ExternalQuotes:15, ExternalQuotes:16, ExternalQuotes:10, ExternalQuotes:11")]
        public ActionResult<IEnumerable<string>> GetAll()
        {
            // return _quote.getAll();
            return new string[] {"Values 1", "Values 2", "Values 3"};
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        // [Authorize(Roles = "ExternalQuotes:6, ExternalQuotes:5, ExternalQuotes:12, ExternalQuotes:13, ExternalQuotes:15, ExternalQuotes:16, ExternalQuotes:10, ExternalQuotes:11")]
        public string GetById(int id)
        {
            // return _quote.getById(id);
            return $"Value {id}";
        }

        // POST api/<controller>
        // [HttpPost]
        // [Authorize(Roles = "ExternalQuotes:12, ExternalQuotes:13, ExternalQuotes:15, ExternalQuotes:16")]
        // public IActionResult Create([FromBody]Quote quote)
        // {
        //     var res = _quote.addQuote(quote);
        //     if (res == true)
        //         return CreatedAtRoute("ExternalQuoteById", new { Controller = "ExternalQuotes", id = quote.QuoteId }, quote);
        //     return StatusCode(500);
        // }

        // PUT api/<controller>/5
        // [HttpPut("{id}")]
        // [Authorize(Roles = "ExternalQuotes:15, ExternalQuotes:16, ExternalQuotes:10, ExternalQuotes:11")]
        // public IActionResult Update(int id, [FromBody]Quote quote)
        // {
        //     var res = _quote.updateQuote(id, quote);

        //     if (res == true)
        //         return new NoContentResult();
        //     return StatusCode(500);
        // }

        // DELETE api/<controller>/5
        // [HttpDelete("{id}")]
        // [Authorize(Roles = "ExternalQuotes:13, ExternalQuotes:16, ExternalQuotes:11, ExternalQuotes:6")]
        // public IActionResult Delete(int id)
        // {
        //     var res = _quote.deleteQuote(id);
        //     if (res == true)
        //         return new NoContentResult();
        //     return StatusCode(500);
        // }
    }
}
