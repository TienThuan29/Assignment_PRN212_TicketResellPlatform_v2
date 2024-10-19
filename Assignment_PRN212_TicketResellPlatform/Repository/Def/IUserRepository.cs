using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Def
{
    public interface IUserRepository
    {
        User FindByUsername(string username);

        bool SaveRegisterUser(User user);

        bool SaveNewPassword(long userId, string newPassword);

        bool SaveProfile(User user);
    }
}
