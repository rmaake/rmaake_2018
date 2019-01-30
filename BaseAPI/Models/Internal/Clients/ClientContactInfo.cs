using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseAPI.Models.Internal.Clients
{
    public class ClientContactInfo
    {
        public int ClientContactInfoId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Cell { get; set; }
        public string Tell { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string AccessCode { get; set; }
        public string AcquisitionNumber { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }

        public int ClientId { get; set; }
        public virtual Client Clients { get; set; }
    }
}
