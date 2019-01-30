using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal;
namespace BaseAPI.Repository.Tools
{
    public interface IComMail
    {
        void SendMailToPar(ComMails data);
    }
}
