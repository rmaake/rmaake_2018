using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BaseAPI.Repository.Internal.Projects.CostsEstimates;
using BaseAPI.Models.Internal.Projects.CostEstimates;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseAPI.Controllers.Internal.Projects.CostsEstimates
{
    [Route("api/[controller]")]
    [EnableCors("AllowAnyOrigin")]
    public class CostEstimateController : Controller
    {
        private ICostEstimateRepo _costEstimate;

        public CostEstimateController(ICostEstimateRepo costEstimate)
        {
            _costEstimate = costEstimate;
        }
        // GET: api/<controller>
        [HttpGet]
        [Authorize(Roles = "CostEstimate:6, CostEstimate:5, CostEstimate:12, CostEstimate:13, CostEstimate:15, CostEstimate:16, CostEstimate:10, CostEstimate:11")]
        public IEnumerable<CostEstimate> GetAll()
        {
            return _costEstimate.getAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "CostEstimateById")]
        [Authorize(Roles = "CostEstimate:6, CostEstimate:5, CostEstimate:12, CostEstimate:13, CostEstimate:15, CostEstimate:16, CostEstimate:10, CostEstimate:11")]
        public CostEstimate GetById(int id)
        {
            return _costEstimate.getById(id);
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Roles = "CostEstimate:12, CostEstimate:13, CostEstimate:15, CostEstimate:16")]
        public IActionResult Create([FromBody] CostEstimate costEstimate)
        {
            var res = _costEstimate.add(costEstimate);
            if (res == true)
                return CreatedAtRoute("CostEstimateById", new { Controller = "CostEstimate", id =  costEstimate.CostEstimateId }, costEstimate);
            return StatusCode(500);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "CostEstimate:15, CostEstimate:16, CostEstimate:10, CostEstimate:11")]
        public IActionResult Update(int id, [FromBody]CostEstimate costEstimate)
        {
            return _costEstimate.update(id, costEstimate) ? new NoContentResult() : StatusCode(500);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "CostEstimate:13, CostEstimate:16, CostEstimate:11, CostEstimate:6")]
        public IActionResult Delete(int id)
        {
            return _costEstimate.delete(id) ? new NoContentResult() : StatusCode(500);
        }
    }
}
