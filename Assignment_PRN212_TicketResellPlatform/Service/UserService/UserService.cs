using BusinessObject;
using Repository.Def;
using Repository.Impl;
using Service.Constant;
using Service.Utils.TienThuan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IStaffRepository staffRepository;

        public UserService() 
        {
            this.userRepository = new UserRepository();
            this.staffRepository = new StaffRepository();   
        }

        public BusinessObject.User FindByUsername(string username)
        {
            return userRepository.FindByUsername(username);
        }

        public bool CheckExistUsername(string username) 
        {
            return userRepository.FindByUsername(username) != null ||
                   staffRepository.FindByUsername(username) != null;
        }

        public bool SaveRegisterUser(string username, string password, string firtsname, string lastname, string email)
        {
            bool flag = true;
            BusinessObject.User user = new BusinessObject.User();
            user.Username = username;   
            user.Password = password;
            user.Lastname = lastname;
            user.Firstname = firtsname;
            user.Email = email;
            user.Balance = 0;
            user.IsEnable = true;   
            user.IsSeller = false;
            user.RoleCode = Role.USER;
            user.CustomerCode = RandomUtil.RandomString(10); // customer code have 10 length
            try
            {
                flag = userRepository.SaveRegisterUser(user);
            }
            catch(Exception ex)
            {
                flag = false;
            }
            return flag;
        }
    }
}

