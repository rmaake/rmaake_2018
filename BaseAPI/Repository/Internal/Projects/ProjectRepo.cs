using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Projects;
using BaseAPI.Models;

namespace BaseAPI.Repository.Internal.Projects
{
    public class ProjectRepo : IProjectRepo
    {
        private BaseApiContext _context;
        public ProjectRepo(BaseApiContext context)
        {
            _context = context;
        }

        public IEnumerable<Project> getAll()
        {
            return _context.Projects.ToList();
        }
        public Project getById(int id)
        {
            return _context.Projects.Where(obj => obj.ProjectId == id).SingleOrDefault();
        }
        public bool add(Project project)
        {
            try
            {
                project.Date = DateTime.Now;
                _context.Projects.Add(project);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            return true;
        }
        public bool update(int id, Project project)
        {
            project.ProjectId = id;
            try
            {
                _context.Projects.Update(project);
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
                _context.Projects.Remove(tmp);
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
