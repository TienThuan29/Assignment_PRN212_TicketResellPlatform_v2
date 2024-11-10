using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.AdminService
{
    public interface IPolicyService
    {
        public List<Policy> GetPolicies();

        public List<Policy> Search(string query);

        public List<TypePolicy> GetAllTypePolicies();

        public TypePolicy GetTypePolicyByName(string name);

        bool AddPolicy(Policy policy);

        TypePolicy GetTypePolicyByid(long id);

        bool ChangeEnableOfPolicy(string id);
    }
}
