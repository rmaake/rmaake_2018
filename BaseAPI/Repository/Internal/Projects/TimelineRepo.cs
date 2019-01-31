using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Projects;
using BaseAPI.Models;

namespace BaseAPI.Repository.Internal.Projects
{
    public class TimelineRepo : ITimelineRepo
    {
        private BaseApiContext _context;
        public TimelineRepo(BaseApiContext context)
        {
            _context = context;
        }

        public IEnumerable<Timeline> getAll()
        {
            return _context.Timelines.ToList();
        }
        public IEnumerable<Timeline> getByProjectId(int id)
        {
            return _context.Timelines.Where(obj => obj.TimelineId == id).ToList();
        }
        public Timeline getById(int id)
        {
            return _context.Timelines.Where(obj => obj.TimelineId == id).SingleOrDefault();
        }
        public bool add(Timeline timeline)
        {
            try
            {
                _context.Timelines.Add(timeline);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            return true;
        }
        public bool update(int id, Timeline timeline)
        {
            timeline.TimelineId = id;
            try
            {
                _context.Timelines.Update(timeline);
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
                _context.Timelines.Remove(tmp);
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
