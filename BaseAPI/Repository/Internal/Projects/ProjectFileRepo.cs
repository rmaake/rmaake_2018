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
    public class ProjectFileRepo : IProjectFileRepo
    {
        private BaseApiContext _context;
        private IHostingEnvironment _hostingEnvironment;
        public ProjectFileRepo(BaseApiContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        public IEnumerable<ProjectFile> getAll()
        {
            return _context.ProjectFiles.ToList();
        }
        public ProjectFile getById(int id)
        {
            return _context.ProjectFiles.Where(opt => opt.ProjectFileId == id).SingleOrDefault();
        }
        public bool add(ProjectFile file)
        {
            try
            {
                _context.ProjectFiles.Add(file);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
               
                return false;
            }
        }
        public bool update(int id, ProjectFile file)
        {
            try
            {
                _context.ProjectFiles.Update(file);
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
                _context.ProjectFiles.Remove(tmp);
                string webRootPath = _hostingEnvironment.WebRootPath;
                string newPath = Path.Combine(webRootPath, tmp.FilePath);
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

