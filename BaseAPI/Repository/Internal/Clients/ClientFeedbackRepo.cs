using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Clients;
using BaseAPI.Models;
namespace BaseAPI.Repository.Internal.Clients
{
    public class ClientFeedbackRepo : IClientFeedbackRepo
    {
        private BaseApiContext _context;
        public ClientFeedbackRepo(BaseApiContext context)
        {
            _context = context;
        }

        public IEnumerable<ClientFeedback> getAll()
        {
            return _context.ClientFeedbacks.ToList();
        }
        public ClientFeedback getById(int id)
        {
            return _context.ClientFeedbacks.Where(obj => obj.ClientFeedbackId == id).SingleOrDefault();
        }
        public bool add(ClientFeedback client)
        {
            try
            {
                client.Date = DateTime.Now;
                _context.ClientFeedbacks.Add(client);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            return true;
        }
        public bool update(int id, ClientFeedback client)
        {
            client.ClientFeedbackId = id;
            try
            {
                _context.ClientFeedbacks.Update(client);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            return true;
        }
        public bool delete(int id)
        {
            var tmp = getById(id);
            try
            {
                _context.ClientFeedbacks.Remove(tmp);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            return true;
        }
    }
}
