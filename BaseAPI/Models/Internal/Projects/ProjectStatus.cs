using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseAPI.Models.Internal.Projects
{
    public class ProjectStatus
    {
        public int ProjectStatusId { get; set; }
        public string Description { get; set; }
        public string Stage { get; set; }

        public virtual List<Timeline> Timelines { get; set; }
    }
}
