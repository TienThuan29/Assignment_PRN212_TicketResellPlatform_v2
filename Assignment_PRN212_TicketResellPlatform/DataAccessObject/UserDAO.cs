﻿using BusinessObject;
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
    }
}
