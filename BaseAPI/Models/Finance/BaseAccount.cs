using System;
using System.Collections.Generic;
using System.Linq;

namespace BaseAPI.Models.Finance {
    public class BaseAccount : ControlAccount {
        public int  BaseAccountId { get; set; }

        public virtual List<MainAccount> accounts { get; set; }

    }
}