using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Projects.Defaults;

namespace BaseAPI.Repository.Internal.Projects.Defaults
{
    public interface IDefaultRepo
    {
        IEnumerable<Default> getAll();
        Default getById(int id);
        bool add(Default Default);
        bool update(int id, Default Default);
        bool delete(int id);
    }
}
