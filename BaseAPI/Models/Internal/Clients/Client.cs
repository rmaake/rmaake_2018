using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Projects;
using System.ComponentModel.DataAnnotations;

namespace BaseAPI.Models.Internal.Clients
{
    public class Client
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string VatNumber { get; set; }
        public string Address { get; set; }
        

        public virtual List<ClientContactInfo> ClientContactInfo { get; set; }
        public virtual List<Project> Project { get; set; }
    }
}
