using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Employees;

namespace BaseAPI.Models.Internal.Projects.CostEstimates
{
    public class CostEstimate
    {
        public int CostEstimateId { get; set; }
        public DateTime Date { get; set; }
  
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Project Project { get; set; }
        public virtual List<CostEstimateItem> CostEstimateItems { get; set; }
    }
}
