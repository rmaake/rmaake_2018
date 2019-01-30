using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Projects.CostEstimates;

namespace BaseAPI.Repository.Internal.Projects.CostsEstimates
{
    public interface ICostEstimateRepo
    {
        IEnumerable<CostEstimate> getAll();
        CostEstimate getById(int id);
        bool add(CostEstimate costEstimate);
        bool update(int id, CostEstimate costEstimate);
        bool delete(int id);
    }
}
