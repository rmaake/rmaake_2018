using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseAPI.Models.Internal.Projects
{
    public class Timeline
    {
        public int TimelineId { get; set; }
        public string Stage { get; set; }
        public string Description { get; set; }
        public bool OverallTimeline { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? Extension { get; set; }

        public int ProjectId { get; set; }
        public int ProjectStatusId { get; set; }
        public virtual ProjectStatus ProjectStatus { get; set; }
        public virtual Project Project { get; set; }
        public virtual List<EmployeeTimeline> EmployeeTimelines { get; set; }
    }
}
