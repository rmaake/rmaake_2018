
using System.Collections.Generic;
using BaseAPI.Models.Finance;
using BaseAPI.Repository.Finance;

namespace BaseAPI.Controllers.Finance {
    public class BaseAccountController {
        private BaseAccountRepo _repo;
        public BaseAccountController(BaseAccountRepo repo) {
            _repo = repo;
        }
        public IEnumerable<BaseAccount> getAllBaseAccount() {
            return (_repo.getAll());
        }
    }
}