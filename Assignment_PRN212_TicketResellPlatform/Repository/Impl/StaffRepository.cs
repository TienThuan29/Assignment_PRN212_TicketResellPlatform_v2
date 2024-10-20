﻿using BusinessObject;
using DataAccessObject;
using Repository.Def;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Impl
{
    public class StaffRepository : IStaffRepository
    {
        public Staff FindByUsername(string username)
        {
            return StaffDAO.Instance.FindByUsername(username);  
        }
    }
}
