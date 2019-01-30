using System;

namespace BaseAPI.Models.Finance {
    public class Transaction {
        public long TransactionId { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public DateTime dateTime { get; set; }
        public float amount { get; set; }
        public bool increase { get; set; }

        public int mainAccountId { get; set; }
        public virtual MainAccount MainAccount { get; set; }
    }
}