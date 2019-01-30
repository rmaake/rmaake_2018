using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseAPI.Repository.Tools
{
    public interface IMailService
    {
        void SendMail(string to, string msg, string subject);
    }
}
