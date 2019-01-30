using BaseAPI.Models.External.Suppliers;
using BaseAPI.Models.Internal.Clients;

namespace BaseAPI.Models.Finance {
    public class Accounts : ControlAccount {
        public long AccountsId { get; set; }
        public bool isDebtor { get; set; }
        public bool isCreditor { get; set; }
        public bool isBank { get; set; }

        public int mainAccountId { get; set; }
        public int ClientId { get; set; }
        public int SupplierId { get; set; }
    }
}