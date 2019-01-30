using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Projects;
namespace BaseAPI.Repository.Internal.Projects
{
    public interface IProjectContentRepo
    {
        IEnumerable<ProjectContent> getAll();
        ProjectContent getById(int id);
        bool add(ProjectContent projectContent);
        bool update(int id, ProjectContent projectContent);
        bool delete(int id);
    }
}
