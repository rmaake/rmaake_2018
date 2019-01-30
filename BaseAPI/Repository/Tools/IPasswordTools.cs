using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseAPI.Repository.Tools
{
    public interface IPasswordTools
    {
        string passwordGen(int length);
        string passwordHash(string password);
    }
}
