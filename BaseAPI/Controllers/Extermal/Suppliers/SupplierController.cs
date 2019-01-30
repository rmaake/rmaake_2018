using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BaseAPI.Models.External.Suppliers;
using BaseAPI.Repository.External.Suppliers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseAPI.Controllers.Extermal.Suppliers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAnyOrigin")]
    public class SupplierController : Controller
    {
        private ISupplierRepo _supplier;
        public SupplierController(ISupplierRepo supplier)
        {
            _supplier = supplier;
        }
        // GET: api/<controller>
        [HttpGet]
        // [Authorize(Roles = "ExternalSupplier:6, ExternalSupplier:5, ExternalSupplier:12, ExternalSupplier:13, ExternalSupplier:15, ExternalSupplier:16, ExternalSupplier:10, ExternalSupplier:11")]
        public IEnumerable<Supplier> GetAll()
        {
            return _supplier.getAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}",Name = "SupplierById")]
        // [Authorize(Roles = "ExternalSupplier:6, ExternalSupplier:5, ExternalSupplier:12, ExternalSupplier:13, ExternalSupplier:15, ExternalSupplier:16, ExternalSupplier:10, ExternalSupplier:11")]
        public Supplier GetById(int id)
        {
            return _supplier.getById(id);
        }

        // POST api/<controller>
        [HttpPost]
        // [Authorize(Roles = "ExternalSupplier:12, ExternalSupplier:13, ExternalSupplier:15, ExternalSupplier:16")]
        public IActionResult Create([FromBody]Supplier supplier)
        {
            var res = _supplier.addSupplier(supplier);
            if (res == true)
                return CreatedAtRoute("SupplierById", new { Controller = "ExternalSupplier", id = supplier.SupplierId }, supplier);
            return StatusCode(500);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        // [Authorize(Roles = "ExternalSupplier:15, ExternalSupplier:16, ExternalSupplier:10, ExternalSupplier:11")]
        public IActionResult Update(int id, [FromBody]Supplier supplier)
        {
            return _supplier.updateSupplier(id, supplier) ? new NoContentResult() : StatusCode(500);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        // [Authorize(Roles = "ExternalSupplier:13, ExternalSupplier:16, ExternalSupplier:11, ExternalSupplier:6")]
        public IActionResult Delete(int id)
        {
            return _supplier.deleteSupplier(id) ? new NoContentResult() : StatusCode(500);
        }
    }
}
