using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseAPI.Models.Internal.Projects.CostEstimates
{
    public class CostEstimateItem
    {
        public int CostEstimateItemId { get; set; }
        public double MaterialPrice { get; set; }
        public double MaterialPercentage { get; set; }
        public double LabourPrice { get; set; }
        public double LabourPercentage { get; set; }
        public double EquipmentPrice { get; set; }
        public double EquipmentPercentage { get; set; }

        public int CostEstimateId { get; set; }
        public virtual CostEstimate CostEstimate { get; set; }
    }
}
