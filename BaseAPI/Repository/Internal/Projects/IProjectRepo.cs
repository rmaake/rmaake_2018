using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Projects;

namespace BaseAPI.Repository.Internal.Projects
{
    public interface IProjectRepo
    {
        IEnumerable<Project> getAll();
        Project getById(int id);
        bool add(Project project);
        bool update(int id, Project project);
        bool delete(int id);
    }
}
