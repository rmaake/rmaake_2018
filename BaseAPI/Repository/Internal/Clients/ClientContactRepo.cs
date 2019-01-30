using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Clients;
using BaseAPI.Models;
using BaseAPI.Repository.Tools;
using BaseAPI.Models.Internal;
namespace BaseAPI.Repository.Internal.Clients
{
    public class ClientContactRepo : IClientContactInfoRepo
    {
        private BaseApiContext _context;
        private IPasswordTools _passwordTools;
        private IComMail _comMail;
        public ClientContactRepo(BaseApiContext context, IPasswordTools passwordTools, IComMail comMail)
        {
            _passwordTools = passwordTools;
            _context = context;
            _comMail = comMail;
        }

        public IEnumerable<ClientContactInfo> getAll()
        {
            return _context.ClientContactInfos.ToList();
        }
        public ClientContactInfo getById(int id)
        {
            return _context.ClientContactInfos.Where(obj => obj.ClientContactInfoId == id).SingleOrDefault();
        }
        public ClientContactInfo getByUsername(string username)
        {
            return _context.ClientContactInfos.Where(obj => username.Equals(username) == true).SingleOrDefault();
        }
        public bool add(ClientContactInfo clientContact)
        {
            var tmp = new ComMails();
            var rnd = new Random();
            var pwd = _passwordTools.passwordGen(10);
            clientContact.Username = clientContact.FirstName[0] + clientContact.LastName + rnd.Next(clientContact.LastName.Length * 1000).ToString();
            clientContact.Password = _passwordTools.passwordHash(pwd);
            tmp.Email = new List<string>();
            tmp.Email.Add(clientContact.Email);
            tmp.Message = "Please find below, your credentials to NRP Portal:<br/>Sign in as Client<br/>";
            tmp.Message += "Username " + clientContact.Username + "<br/>Password: " + pwd;
            _comMail.SendMailToPar(tmp);
            try
            {
                clientContact.Date = DateTime.Now;
                _context.ClientContactInfos.Add(clientContact);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            return true;
        }
        public bool update(int id, ClientContactInfo clientContact)
        {
            clientContact.ClientContactInfoId = id;
            try
            {
                _context.ClientContactInfos.Update(clientContact);
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
                _context.ClientContactInfos.Remove(tmp);
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
