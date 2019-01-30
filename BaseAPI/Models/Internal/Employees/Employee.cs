using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Projects.CostEstimates;
using BaseAPI.Models.Internal.Credentials;
namespace BaseAPI.Models.Internal.Employees
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string MaidenName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string AlternativeNumber { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }
        public string SAID { get; set; }
        public string PassportNumber { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ImagePath { get; set; }
        public string AccessCode { get; set; }

        public virtual List<EmployeeAccounts> EmployeesAccounts { get; set; }
        public virtual List<EmployeeKin> EmployeesKin { get; set; }
        public virtual List<CostEstimate> CostEstimate { get; set; }
        public virtual List<EmployeeTimeline> EmployeeTimelines { get; set; }
    }
}
