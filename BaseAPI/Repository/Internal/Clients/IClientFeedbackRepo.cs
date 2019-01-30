using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Clients;

namespace BaseAPI.Repository.Internal.Clients
{
    public interface IClientFeedbackRepo
    {
        IEnumerable<ClientFeedback> getAll();
        ClientFeedback getById(int id);
        bool add(ClientFeedback feedback);
        bool update(int id, ClientFeedback feedback);
        bool delete(int id);
    }
}
