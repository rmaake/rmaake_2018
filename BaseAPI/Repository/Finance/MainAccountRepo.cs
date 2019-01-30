using BaseAPI.Models;
using BaseAPI.Models.Finance;
using System.Collections.Generic;
using System.Linq;

namespace BaseAPI.Repository.Finance {
    public class MainAccountRepo {
        private BaseApiContext _context;

        public MainAccountRepo(BaseApiContext context) {
            _context = context;
        }

        private void addMainAccount(string name, bool dbIncrease, BaseAccount baseAccount) {
            MainAccount tempAccount = new MainAccount();

            tempAccount.name = name;
            tempAccount.dbIncrease = dbIncrease;
            tempAccount.isIncrease = true;
            tempAccount.amount = 0;
            tempAccount.balance = 0;
            tempAccount.BaseAccountId = baseAccount.BaseAccountId;
            _context.MainAccounts.Add(tempAccount);            
        }

        private void addAssetAccounts(BaseAccount baseAccount) {
            this.addMainAccount("Current", baseAccount.dbIncrease, baseAccount);
            this.addMainAccount("Fixed", baseAccount.dbIncrease, baseAccount);
            this.addMainAccount("Other", baseAccount.dbIncrease, baseAccount);
        }

        private void addLiabilityAccounts(BaseAccount baseAccount) {
            this.addMainAccount("Current", baseAccount.dbIncrease, baseAccount);
            this.addMainAccount("Long-Term", baseAccount.dbIncrease, baseAccount);
        }

        private void addOwnersEquityAccounts(BaseAccount baseAccount) {
            this.addMainAccount("equity", baseAccount.dbIncrease, baseAccount);
            this.addMainAccount("revenue", baseAccount.dbIncrease, baseAccount);
            this.addMainAccount("expense-cost", false, baseAccount);
            this.addMainAccount("expense", false, baseAccount);
        }

        public void initMainAccountRepo(IEnumerable<BaseAccount> BaseAccounts) {
            foreach (BaseAccount oneBaseAccount in BaseAccounts) {
                if (string.Compare(oneBaseAccount.name, "Asset", true) == 0) {
                    this.addAssetAccounts(oneBaseAccount);
                }
                else if (string.Compare(oneBaseAccount.name, "Owners Equity", true) == 0) {
                    this.addOwnersEquityAccounts(oneBaseAccount);                    
                }
                else if (string.Compare(oneBaseAccount.name, "Liability", true) == 0) {
                    this.addLiabilityAccounts(oneBaseAccount);
                }
            }
            _context.SaveChanges();
        }

        public List<MainAccount> getAll() {
            List<MainAccount> tempData = _context.MainAccounts.ToList();

            if (tempData.Count() == 0) {
                this.initMainAccountRepo(_context.BaseAccounts.ToList());
                return (getAll());
            }
            return tempData;
        }
    }
}