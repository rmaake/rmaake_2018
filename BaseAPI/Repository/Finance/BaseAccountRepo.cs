using System.Collections.Generic;
using BaseAPI.Models.Finance;
using BaseAPI.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BaseAPI.Repository.Finance {
    public class BaseAccountRepo {

        private BaseApiContext _context;

        public BaseAccountRepo(BaseApiContext context) {
            _context = context;
        }

        private void newBaseAccount(string name, bool dbIncrease) {
            BaseAccount tempAccount = new BaseAccount();
            tempAccount.balance = 0;
            tempAccount.dbIncrease = dbIncrease;
            tempAccount.name = name;
            tempAccount.amount = 0;
            tempAccount.isIncrease = true;
            _context.BaseAccounts.Add(tempAccount);
            // _context.SaveChanges();
        }

        private void initBaseAccount() {
            this.newBaseAccount("Asset", true);
            this.newBaseAccount("Owners Equity", true);
            this.newBaseAccount("Liability", false);
            _context.SaveChanges();
        }

        public List<BaseAccount> getAll() {
            List<BaseAccount> apiContext;

            // _context.BaseAccounts.Include(c => c.accounts).ToList();
            // if ((apiContext = _context.BaseAccounts.ToList()).Count() == 0) {
            if ((apiContext = _context.BaseAccounts.Include(c => c.accounts).ToList()).Count() == 0) {
                this.initBaseAccount();
                // MainAccountRepo.initMainAccountRepo(this.getAll());
                return (this.getAll());
            }
            return (apiContext);
        }
    }
}