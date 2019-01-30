using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Clients;
using BaseAPI.Models;
namespace BaseAPI.Repository.Internal.Clients
{
    public class FeedbackCommentRepo : IFeedbackCommentRepo
    {
        private BaseApiContext _context;
        public FeedbackCommentRepo(BaseApiContext context)
        {
            _context = context;
        }

        public IEnumerable<FeedbackComment> getAll()
        {
            return _context.FeedbackComments.ToList();
        }
        public FeedbackComment getById(int id)
        {
            return _context.FeedbackComments.Where(obj => obj.FeedbackCommentId == id).SingleOrDefault();
        }
        public bool add(FeedbackComment client)
        {
            try
            {
                client.Date = DateTime.Now;
                _context.FeedbackComments.Add(client);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            return true;
        }
        public bool update(int id, FeedbackComment client)
        {
            client.FeedbackCommentId = id;
            try
            {
                _context.FeedbackComments.Update(client);
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
                _context.FeedbackComments.Remove(tmp);
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
