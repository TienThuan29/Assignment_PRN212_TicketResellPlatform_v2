﻿using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Def
{
    public interface IPolicyRepository
    {
        public List<Policy> GetPolicies();

        public List<Policy> Search(string query);
    }
}
