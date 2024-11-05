using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Def
{
    public interface IPolicyRepository
    {
        List<Policy> GetPolicies();

        List<Policy> Search(string query);

        List<TypePolicy> GetAllTypePolicies();

        TypePolicy GetTypePolicyByName(string name);

        bool AddPolicy(Policy policy);

        TypePolicy GetTypePolicyByid(long id);
    }
}
