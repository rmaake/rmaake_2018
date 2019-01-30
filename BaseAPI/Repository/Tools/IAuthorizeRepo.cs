using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Credentials;
using BaseAPI.Models.Internal.Clients;
using BaseAPI.Models.Internal.Employees;

namespace BaseAPI.Repository.Tools
{
    public interface IAuthorizeRepo
    {
        //bool verifyAccess(string accessTo, string accessCode);
        Employee employeeLogin(UserCredentials credentials);
        ClientContactInfo clientLogin(UserCredentials credentials);
        Employee getEmployee(int id);
        ClientContactInfo getClient(int id);
    }
}
