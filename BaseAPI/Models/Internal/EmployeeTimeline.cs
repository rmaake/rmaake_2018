using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Employees;
using BaseAPI.Models.Internal.Projects;

namespace BaseAPI.Models.Internal
{
    public class EmployeeTimeline
    {
        public int EmployeeTimelineId { get; set; }
        public int? EmployeeId { get; set; }
        public int? TimelineId { get; set; }
        public int? ProjectId { get; set; }
        public int? EmployeeRoleId { get; set; }

        public Employee Employee { get; set; }
        public Project Project { get; set; }
        public Timeline Timeline { get; set; }
        public EmployeeRole EmployeeRole { get; set; }
    }
}
