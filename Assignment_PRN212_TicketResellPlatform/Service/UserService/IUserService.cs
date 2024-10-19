using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.User
{
    public interface IUserService
    {
        BusinessObject.User FindByUsername(string username);

        bool CheckExistUsername(string username);

        bool SaveRegisterUser(string username, string password, string firtsname, string lastname, string email);    
    }
}
