using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseAPI.Repository.Tools
{
    public class MailConfig : IMailConfig
    {
        public string password { get; set; }
        public string smtpHost { get; set; }
        public string serverUserId { get; set; }

        public int serverPort { get; set; }
    }
}
