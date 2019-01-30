using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BaseAPI.Models;
using System.Linq;
using BaseAPI.Repository.Finance;
using BaseAPI.Models.Finance;

namespace BaseAPI.Controllers.Finance {
    [Route("api/[controller]")]
    public class FinanceSetupController : ControllerBase {

        private BaseApiContext _context;
        private BaseAccountRepo _repo;

        public FinanceSetupController(BaseApiContext context) {
            _context = context;
            _repo = new BaseAccountRepo(_context);
        }

        [HttpGet]
        // [Authorize(Roles = "ExternalQuotes:6, ExternalQuotes:5, ExternalQuotes:12, ExternalQuotes:13, ExternalQuotes:15, ExternalQuotes:16, ExternalQuotes:10, ExternalQuotes:11")]
        public IEnumerable<BaseAccount> GetAll() {
            MainAccountRepo _mainAccountRepo = new MainAccountRepo(_context);
            AccountRepo _accountRepo = new AccountRepo(_context);

            _repo.getAll();
            _mainAccountRepo.getAll();
            _accountRepo.getAll();
            return (_repo.getAll());
        }

        [HttpDelete]
        public void DeleteAll()
        {
            // MainAccountRepo _mainAccountRepo = new MainAccountRepo(_context);
            // AccountRepo _accountRepo = new AccountRepo(_context);

            // _context.BaseAccounts.RemoveRange(_repo.getAll());
            // _context.MainAccounts.RemoveRange(_mainAccountRepo.getAll());
            // _context.Accounts.RemoveRange(_accountRepo.getAll());
            // _context.SaveChanges();
        }
    }
}