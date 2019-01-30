using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Clients;

namespace BaseAPI.Repository.Internal.Clients
{
    public interface IClientContactInfoRepo
    {
        IEnumerable<ClientContactInfo> getAll();
        ClientContactInfo getById(int id);
        bool add(ClientContactInfo clientContactInfo);
        bool update(int id, ClientContactInfo clientContactInfo);
        bool delete(int id);
    }
}
