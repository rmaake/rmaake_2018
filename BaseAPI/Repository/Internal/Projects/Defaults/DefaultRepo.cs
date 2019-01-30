using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Projects.Defaults;
using BaseAPI.Models;

namespace BaseAPI.Repository.Internal.Projects.Defaults
{
    public class DefaultRepo : IDefaultRepo
    {
        private BaseApiContext _context;
        public DefaultRepo(BaseApiContext context)
        {
            _context = context;
        }

        public IEnumerable<Default> getAll()
        {
            return _context.Defaults.ToList();
        }
        public Default getById(int id)
        {
            return _context.Defaults.Where(obj => obj.DefaultId == id).SingleOrDefault();
        }
        public bool add(Default Default)
        {
            try
            {
                Default.Date = DateTime.Now;
                _context.Defaults.Add(Default);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            return true;
        }
        public bool update(int id, Default Default)
        {
            Default.DefaultId = id;
            try
            {
                _context.Defaults.Update(Default);
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
                _context.Defaults.Remove(tmp);
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
