using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Projects;

namespace BaseAPI.Repository.Internal.Projects
{
    public interface ITimelineRepo
    {
        IEnumerable<Timeline> getAll();
        Timeline getById(int id);
        IEnumerable<Timeline> getByProjectId(int id);
        bool add(Timeline timeline);
        bool update(int id, Timeline timeline);
        bool delete(int id);
    }
}
