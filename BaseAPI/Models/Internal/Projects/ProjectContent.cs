using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Clients;
using BaseAPI.Models.Internal.Employees;

namespace BaseAPI.Models.Internal.Projects
{
    public class ProjectContent
    {
        public int ProjectContentId { get; set; }
        public string ImagePath { get; set; }
        public string VoiceNotePath { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public int TimelineId { get; set; }
        public int? EmployeeId { get; set; }
        public int? ClientContactInfoId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ClientContactInfo Client { get; set; }
        public virtual Timeline Timeline { get; set; }
       
    }
}
