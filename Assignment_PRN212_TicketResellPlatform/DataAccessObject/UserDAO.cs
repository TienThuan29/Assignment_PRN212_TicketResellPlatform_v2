using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class UserDAO
    {
        private PRN212_TicketResellPlatformContext context;

        private static UserDAO instance;

        public static UserDAO Instance
        {
            get => instance = instance ?? (instance = new UserDAO());
        }

        private UserDAO()
        {
            this.context = new PRN212_TicketResellPlatformContext();
        }

        public User FindByUsername(string username)
        {
            return context.Users.SingleOrDefault(obj => obj.Username.Equals(username));
        }

        public User FindById(long id)
        {
            return context.Users.SingleOrDefault(obj => obj.Id.Equals(id));
        }

        public bool SaveRegisterUser(User user)
        {
            bool flag = true;
            if (user != null)
            {
                this.context.Users.Add(user);
                this.context.SaveChanges();
            }
            else
            {
                flag = false;
            }
            return flag;
        }

        public bool SaveProfile(User user)
        {
            bool flag = true;
            if (user != null)
            {
                this.context.Entry<User>(user).CurrentValues.SetValues(user);
                this.context.SaveChanges();
            }
            else flag = false;
            return flag;
        }

        public bool SaveNewPassword(long userId, string newPassword)
        {
            bool flag = true;
            var user = this.context.Users.SingleOrDefault(obj => obj.Id.Equals(userId));
            if (user != null)
            {
                user.Password = newPassword;
                this.context.Entry<User>(user).CurrentValues.SetValues(user);
                this.context.SaveChanges();
            }
            else flag = false;
            return flag;
        }

        public ICollection<User> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public List<User> Search(string query)
        {
            List<User> users = context.Users.ToList();
            List<User> filtered = new List<User>();
            query = query.ToLower();
            foreach (var user in users) {
                if (user.Id.ToString().Contains(query) || user.Firstname.ToLower().Contains(query) || user.Lastname.ToLower().Contains(query)
                    || user.Email.ToLower().Contains(query) || user.Phone.Contains(query) || user.Revenue.ToString().Contains(query))
                {
                    filtered.Add(user);
                }
            }
            return filtered;
        }
    }
}
