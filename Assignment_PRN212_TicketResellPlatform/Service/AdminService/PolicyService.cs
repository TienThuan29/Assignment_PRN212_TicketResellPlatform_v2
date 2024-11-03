using BusinessObject;
using Repository.Def;
using Repository.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.AdminService
{
    public class PolicyService : IPolicyService
    {   
        private readonly IPolicyRepository policyRepository;

        public PolicyService() 
        { 
            policyRepository = new PolicyRepository();
        }
        public List<Policy> GetPolicies()
        {
            return policyRepository.GetPolicies();
        }
    }
}
