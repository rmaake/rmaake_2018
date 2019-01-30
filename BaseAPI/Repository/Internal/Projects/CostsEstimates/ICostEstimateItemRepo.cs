using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Projects.CostEstimates;

namespace BaseAPI.Repository.Internal.Projects.CostsEstimates
{
    public interface ICostEstimateItemRepo
    {
        IEnumerable<CostEstimateItem> getAll();
        CostEstimateItem getById(int id);
        bool add(CostEstimateItem costEstimateItem);
        bool update(int id, CostEstimateItem costEstimateItem);
        bool delete(int id);
    }
}
