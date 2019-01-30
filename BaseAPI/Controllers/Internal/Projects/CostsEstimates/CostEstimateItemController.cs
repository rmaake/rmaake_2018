using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BaseAPI.Models.Internal.Projects.CostEstimates;
using BaseAPI.Repository.Internal.Projects.CostsEstimates;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseAPI.Controllers.Internal.Projects.CostsEstimates
{
    [Route("api/[controller]")]
    [EnableCors("AllowAnyOrigin")]
    public class CostEstimateItemController : Controller
    {
        private ICostEstimateItemRepo _costEstimateItem;

        public CostEstimateItemController(ICostEstimateItemRepo costEstimateItem)
        {
            _costEstimateItem = costEstimateItem;
        }
        // GET: api/<controller>
        [HttpGet]
        [Authorize(Roles = "CostEstimateItem:6, CostEstimateItem:5, CostEstimateItem:12, CostEstimateItem:13, CostEstimateItem:15, CostEstimateItem:16, CostEstimateItem:10, CostEstimateItem:11")]
        public IEnumerable<CostEstimateItem> GetAll()
        {
            return _costEstimateItem.getAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "CostEstimateItemById")]
        [Authorize(Roles = "CostEstimateItem:6, CostEstimateItem:5, CostEstimateItem:12, CostEstimateItem:13, CostEstimateItem:15, CostEstimateItem:16, CostEstimateItem:10, CostEstimateItem:11")]
        public CostEstimateItem GetById(int id)
        {
            return _costEstimateItem.getById(id);
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Roles = "CostEstimateItem:12, CostEstimateItem:13, CostEstimateItem:15, CostEstimateItem:16")]
        public IActionResult Create([FromBody] CostEstimateItem costEstimateItem)
        {
            var res = _costEstimateItem.add(costEstimateItem);
            if (res == true)
                return CreatedAtRoute("CostEstimateItemById", new { Controller = "CostEstimateItem", id = costEstimateItem.CostEstimateItemId }, costEstimateItem);
            return StatusCode(500);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "CostEstimateItem:15, CostEstimateItem:16, CostEstimateItem:10, CostEstimateItem:11")]
        public IActionResult Update(int id, [FromBody]CostEstimateItem costEstimateItem)
        {
            return _costEstimateItem.update(id, costEstimateItem) ? new NoContentResult() : StatusCode(500);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "CostEstimateItem:13, CostEstimateItem:16, CostEstimateItem:11, CostEstimateItem:6")]
        public IActionResult Delete(int id)
        {
            return _costEstimateItem.delete(id) ? new NoContentResult() : StatusCode(500);
        }
    }
}
