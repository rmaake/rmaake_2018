using BaseAPI.Models.Internal.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseAPI.Repository.Internal.Projects
{
    public interface IProjectFileRepo
    {
        IEnumerable<ProjectFile> getAll();
        ProjectFile getById(int id);
        bool add(ProjectFile file);
        bool update(int id, ProjectFile file);
        bool delete(int id);
    }
}
