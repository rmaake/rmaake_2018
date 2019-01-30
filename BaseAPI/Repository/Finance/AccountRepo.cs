using System.Collections.Generic;
using System.Linq;
using BaseAPI.Models;
using BaseAPI.Models.Finance;

namespace BaseAPI.Repository.Finance {

    public class AccountRepo {
        private BaseApiContext _context;

        public AccountRepo(BaseApiContext context) {
            _context = context;
        }

        private void newAccount(string name, bool dbIncrease, MainAccount mainAccount) {
            Accounts account = new Accounts();

            account.name = name;
            account.isDebtor = false;
            account.isCreditor = false;
            account.dbIncrease = dbIncrease;
            account.isIncrease = true;
            account.isBank = false;
            account.mainAccountId = mainAccount.mainAccountId;
            account.ClientId = 0;
            account.SupplierId = 0;
            account.amount = 0;
            account.balance = 0;
            _context.Accounts.Add(account);
        }

        public void addForCurrentAssets(MainAccount account) {
            this.newAccount("Petty Cash", true, account);
            this.newAccount("Cash", true, account);
            this.newAccount("Debtors", true, account);
            this.newAccount("Prepaid Expense", true, account);
        }

        public void addForFixedAssets(MainAccount account) {
            this.newAccount("Furniture and fixtures", true, account);
            this.newAccount("Vehicles", true, account);
            this.newAccount("Land and Building", true, account);
            this.newAccount("Accumulated Depreciation", true, account);
        }

        public void addForEquityOE(MainAccount account) {
            this.newAccount("Capital", true, account);
            this.newAccount("Retained Income", true, account);
            this.newAccount("Dividends", true, account);
        }

        public void addForRevenueOE(MainAccount account) {
            this.newAccount("Revenue", false, account);
            this.newAccount("Interest Recieved", false, account);
            this.newAccount("Rental Income", false, account);
        }

        public void addExpenseCostOE(MainAccount account) {
            this.newAccount("Trading Stock", true, account);
        }

        public void addExpenseOE(MainAccount accounts) {
            this.newAccount("Bad Debts", true, accounts);
            this.newAccount("Advertising", true, accounts);
            this.newAccount("Travel Expense", true, accounts);
            this.newAccount("Equipment lease", true, accounts);
            this.newAccount("Fuel", true, accounts);
            this.newAccount("Rent Expense", true, accounts);
            this.newAccount("Interest Expense", true, accounts);
            this.newAccount("Licence Expense", true, accounts);
            this.newAccount("Telephone", true, accounts);
            this.newAccount("Tax Expense", true, accounts);
            this.newAccount("Supplies", true, accounts);
        }

        public void addCurrentLiablity(MainAccount accounts) {
            this.newAccount("Accounts Payable", false, accounts);
            this.newAccount("Accrued Fees", false, accounts);
            this.newAccount("Payroll Payable", false, accounts);
        }

        private void addLongTermLiability(MainAccount accounts) {
            this.newAccount("Bank Loan Payable", false, accounts);
            this.newAccount("Equipment Payable", false, accounts);
        }

        public void addForAssets(List<MainAccount> accounts) {
            foreach (MainAccount oneAccount in accounts) {
                if (string.Compare(oneAccount.name, "current", true) == 0) {
                    this.addForCurrentAssets(oneAccount);
                }
                else if (string.Compare(oneAccount.name, "fixed", true) == 0) {
                    this.addForFixedAssets(oneAccount);
                }
                else if (string.Compare(oneAccount.name, "other", true) == 0) {
                }
            }
        }

        public void addForOwnersEquity(List<MainAccount> accounts) {
            foreach (MainAccount oneAccount in accounts) {
                if (string.Compare(oneAccount.name, "equity", true) == 0) {
                    this.addForEquityOE(oneAccount);
                }
                else if (string.Compare(oneAccount.name, "revenue", true) == 0) {
                    this.addForRevenueOE(oneAccount);
                }
                else if (string.Compare(oneAccount.name, "expense-cost", true) == 0) {
                    this.addExpenseCostOE(oneAccount);
                }
                else if (string.Compare(oneAccount.name, "expense", true) == 0) {
                    this.addExpenseOE(oneAccount);
                }
            }
        }

        public void addForLiablity(List<MainAccount> accounts) {
            foreach (MainAccount oneAccount in accounts) {
                if (string.Compare(oneAccount.name, "current", true) == 0) {
                    this.addCurrentLiablity(oneAccount);
                }
                else if (string.Compare(oneAccount.name, "long-term", true) == 0) {
                    this.addLongTermLiability(oneAccount);
                }
            }
        }

        public void initAccounts() {
            List<BaseAccount> accounts = _context.BaseAccounts.ToList();

            foreach (BaseAccount oneAccount in accounts) {
                if (string.Compare(oneAccount.name, "asset", true) == 0) {
                    this.addForAssets(oneAccount.accounts);
                }
                else if (string.Compare(oneAccount.name, "Owners Equity", true) == 0) {
                    this.addForOwnersEquity(oneAccount.accounts);
                }
                else if (string.Compare(oneAccount.name, "Liability", true) == 0) {
                    this.addForLiablity(oneAccount.accounts);
                }
            }
            _context.SaveChanges();
        }

        public List<Accounts> getAll() {
            List<Accounts> accounts = _context.Accounts.ToList();

            if (accounts.Count() == 0) {
                this.initAccounts();
            }
            return (accounts);
        }     
    }
}