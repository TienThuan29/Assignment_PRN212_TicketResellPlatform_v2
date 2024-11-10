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

        public bool AddPolicy(Policy policy)
        {
            return policyRepository.AddPolicy(policy);
        }

        public bool ChangeEnableOfPolicy(string id)
        {
            return policyRepository.ChangeEnableOfPolicy(id);
        }

        public List<TypePolicy> GetAllTypePolicies()
        {
            return policyRepository.GetAllTypePolicies();
        }

        public List<Policy> GetPolicies()
        {
            return policyRepository.GetPolicies();
        }

        public Policy GetPolicy(int id)
        {
            return policyRepository.GetPolicy(id);
        }

        public TypePolicy GetTypePolicyByid(long id)
        {
            return policyRepository.GetTypePolicyByid(id);
        }

        public TypePolicy GetTypePolicyByName(string name)
        {
            return policyRepository.GetTypePolicyByName(name);
        }

        public List<Policy> Search(string query)
        {
            return policyRepository.Search(query);
        }

        public bool UpdatePolicy(Policy policy)
        {
            return policyRepository.UpdatePolicy(policy);
        }
    }
}
