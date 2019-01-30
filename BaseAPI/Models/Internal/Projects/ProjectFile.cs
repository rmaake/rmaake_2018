using BaseAPI.Models.Internal.Clients;
using BaseAPI.Models.Internal.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseAPI.Models.Internal.Projects
{
    public class ProjectFile
    {
        public int ProjectFileId { get; set; }
        public string FilePath { get; set; }
        public string Description { get; set; }

        public int ProjectId { get; set; }
        public int? EmployeeId { get; set; }
        public int? ClientContactInfoId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ClientContactInfo Client { get; set; }
        public virtual Project Project { get; set; }
    }
}
