using System.Collections.Generic;
using System.Linq;

namespace BaseAPI.Models.Finance {
    public class MainAccount : ControlAccount {
        public int mainAccountId { get; set; }

        public int BaseAccountId { get; set; }
        public virtual List<Accounts> accounts { get; set; }
    }
}