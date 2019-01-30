using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Projects.Defaults;

namespace BaseAPI.Repository.Internal.Projects.Defaults
{
    public interface IDefaultTypeRepo
    {
        IEnumerable<DefaultType> getAll();
        DefaultType getById(int id);
        bool add(DefaultType DefaultType);
        bool update(int id, DefaultType DefaultType);
        bool delete(int id);
    }
}
