using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models;
using BaseAPI.Models.Internal.Clients;

namespace BaseAPI.Repository.Internal.Clients
{
    public class ClientRepo : IClientRepo
    {
        private BaseApiContext _context;
        public ClientRepo(BaseApiContext context)
        {
            _context = context;
        }

        public IEnumerable<Client> getAll()
        {
            return _context.Clients.ToList();
        }
        public Client getById(int id)
        {
            return _context.Clients.Where(obj => obj.ClientId == id).SingleOrDefault();
        }
        public bool add(Client client)
        {
            try
            {
                _context.Clients.Add(client);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            return true;
        }
        public bool update(int id, Client client)
        {
            client.ClientId = id;
            try
            {
                _context.Clients.Update(client);
                _context.SaveChanges();
            }
            catch(Exception e)
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
                _context.Clients.Remove(tmp);
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
