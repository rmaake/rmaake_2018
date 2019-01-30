using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Projects;
using BaseAPI.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace BaseAPI.Repository.Internal.Projects
{
    public class ProjectContentRepo : IProjectContentRepo
    {
        private BaseApiContext _context;
        private IHostingEnvironment _hostingEnvironment;
        public ProjectContentRepo(BaseApiContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        public IEnumerable<ProjectContent> getAll()
        {
            return _context.ProjectContents.ToList();
        }
        public ProjectContent getById(int id)
        {
            return _context.ProjectContents.Where(opt => opt.ProjectContentId == id).SingleOrDefault();
        }
        public bool add(ProjectContent projectContent)
        {
            try
            {
                projectContent.Date = DateTime.Now;
                _context.ProjectContents.Add(projectContent);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }
        public bool update(int id, ProjectContent projectContent)
        {
            try
            {
                _context.ProjectContents.Update(projectContent);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }
        public bool delete(int id)
        {
            try
            {
                var tmp = getById(id);
                _context.ProjectContents.Remove(tmp);
                string webRootPath = _hostingEnvironment.WebRootPath;
                string newPath = Path.Combine(webRootPath, tmp.ImagePath);
                File.Delete(newPath);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }
    }
}
