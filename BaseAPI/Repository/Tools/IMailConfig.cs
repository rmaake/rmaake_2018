using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseAPI.Repository.Tools
{
    public interface IMailConfig
    {
        string password { get; set; }
        string smtpHost { get; set; }
        string serverUserId { get; set; }
        int serverPort { get; set; }
    }
}
