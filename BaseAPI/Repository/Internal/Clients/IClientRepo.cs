using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Clients;

namespace BaseAPI.Repository.Internal.Clients
{
    public interface IClientRepo
    {
        IEnumerable<Client> getAll();
        Client getById(int id);
        bool add(Client client);
        bool update(int id, Client client);
        bool delete(int id);
    }
}
