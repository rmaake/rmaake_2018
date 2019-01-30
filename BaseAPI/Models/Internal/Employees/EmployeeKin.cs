using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseAPI.Models.Internal.Employees
{
    public class EmployeeKin
    {
        public int EmployeeKinId { get; set; }
        public string FirstName { get; set; }
        public string MaidenName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string AlternativeNumber { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }
        public string SAID { get; set; }
        public string PassportNumber { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

    }
}
