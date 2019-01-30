using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Projects.Defaults;
using BaseAPI.Models;

namespace BaseAPI.Repository.Internal.Projects.Defaults
{
    public class DefaultTypeRepo : IDefaultTypeRepo
    {
        private BaseApiContext _context;
        public DefaultTypeRepo(BaseApiContext context)
        {
            _context = context;
        }

        public IEnumerable<DefaultType> getAll()
        {
            return _context.DefaultTypes.ToList();
        }
        public DefaultType getById(int id)
        {
            return _context.DefaultTypes.Where(obj => obj.DefaultTypeId == id).SingleOrDefault();
        }
        public bool add(DefaultType DefaultType)
        {
            try
            {
                _context.DefaultTypes.Add(DefaultType);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            return true;
        }
        public bool update(int id, DefaultType DefaultType)
        {
            DefaultType.DefaultTypeId = id;
            try
            {
                _context.DefaultTypes.Update(DefaultType);
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
                _context.DefaultTypes.Remove(tmp);
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
