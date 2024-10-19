using BusinessObject;
using DataAccessObject;
using Repository.Def;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Impl
{
    public class UserRepository : IUserRepository
    {
        public User FindByUsername(string username)
        {
            return UserDAO.Instance.FindByUsername(username);   
        }

        public bool SaveNewPassword(long userId, string newPassword)
        {
            return UserDAO.Instance.SaveNewPassword(userId, newPassword);   
        }

        public bool SaveProfile(User user)
        {
            return UserDAO.Instance.SaveProfile(user);
        }

        public bool SaveRegisterUser(User user)
        {
            return UserDAO.Instance.SaveRegisterUser(user);
        }
    }
}
