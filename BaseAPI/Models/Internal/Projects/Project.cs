using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Clients;
using BaseAPI.Models.Internal.Projects.Invoices;

namespace BaseAPI.Models.Internal.Projects
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Facility { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public virtual List<Invoice> Invoices { get; set; }
        public virtual List<Timeline> Timelines { get; set; } 
        public virtual List<EmployeeTimeline> EmployeeTimelines { get; set; }
        public virtual List<ProjectFile> ProjectFiles { get; set; }
    }
}
