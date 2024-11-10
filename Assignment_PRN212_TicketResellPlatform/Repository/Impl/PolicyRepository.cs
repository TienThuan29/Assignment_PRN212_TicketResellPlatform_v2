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
    public class PolicyRepository : IPolicyRepository
    {
        public bool AddPolicy(Policy policy)
        {
            return PolicyDAO.Instance.AddPolicy(policy);
        }

        public bool ChangeEnableOfPolicy(string id)
        {
            return PolicyDAO.Instance.ChangeEnableOfPolicy(id);
        }

        public List<TypePolicy> GetAllTypePolicies()
        {
            return TypePolicyDAO.Instance.GetAllTypePolicies();
        }

        public List<Policy> GetPolicies() => PolicyDAO.Instance.GetPolicies();

        public TypePolicy GetTypePolicyByid(long id)
        {
            return TypePolicyDAO.Instance.GetTypePolicyByid(id);
        }

        public TypePolicy GetTypePolicyByName(string name)
        {
            return TypePolicyDAO.Instance.GetTypePolicyByName(name);
        }

        public List<Policy> Search(string query)
        {
            return PolicyDAO.Instance.Search(query);
        }
    }
}
