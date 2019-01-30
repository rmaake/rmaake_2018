using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BaseAPI.Repository.External.Suppliers;
using BaseAPI.Models.External.Suppliers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseAPI.Controllers.Extermal.Suppliers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAnyOrigin")]
    public class ExternalSupplierAccountController : Controller
    {
        private ISupplierAccountRepo _supplierAccount;

        public ExternalSupplierAccountController(ISupplierAccountRepo supplierAccount)
        {
            _supplierAccount = supplierAccount;
        }

        // GET: api/<controller>
        [HttpGet]
        //[Authorize(Roles = "ExternalSupplierAccount:6, ExternalSupplierAccount:5, ExternalSupplierAccount:12, ExternalSupplierAccount:13, ExternalSupplierAccount:15, ExternalSupplierAccount:16, ExternalSupplierAccount:10, ExternalSupplierAccount:11")]
        public IEnumerable<SupplierAccount> GetAll()
        {
            return _supplierAccount.getAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "SupplierAccountById")]
        //[Authorize(Roles = "ExternalSupplierAccount:6, ExternalSupplierAccount:5, ExternalSupplierAccount:12, ExternalSupplierAccount:13, ExternalSupplierAccount:15, ExternalSupplierAccount:16, ExternalSupplierAccount:10, ExternalSupplierAccount:11")]
        public SupplierAccount GetById(int id)
        {
            return _supplierAccount.getById(id);
        }

        // POST api/<controller>
        [HttpPost]
        //[Authorize(Roles = "ExternalSupplierAccount:12, ExternalSupplierAccount:13, ExternalSupplierAccount:15, ExternalSupplierAccount:16")]
        public IActionResult Create([FromBody]SupplierAccount supplierAccount)
        {
            var res = _supplierAccount.addSupplierAccount(supplierAccount);
            if (res == true)
                return CreatedAtRoute("SupplierAccountById", new { Controller = "ExternalSupplierAccount", id = supplierAccount.SupplierAccountId }, supplierAccount);
            return StatusCode(500);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        //[Authorize(Roles = "ExternalSupplierAccount:15, ExternalSupplierAccount:16, ExternalSupplierAccount:10, ExternalSupplierAccount:11")]
        public IActionResult Update(int id, [FromBody]SupplierAccount supplierAccount)
        {
            return _supplierAccount.updateSupplierAccount(id, supplierAccount) ? new NoContentResult() : StatusCode(500);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        //[Authorize(Roles = "ExternalSupplierAccount:13, ExternalSupplierAccount:16, ExternalSupplierAccount:11, ExternalSupplierAccount:6")]
        public IActionResult Delete(int id)
        {
            return _supplierAccount.deleteSupplierAccount(id) ? new NoContentResult() : StatusCode(500);
        }
    }
}
