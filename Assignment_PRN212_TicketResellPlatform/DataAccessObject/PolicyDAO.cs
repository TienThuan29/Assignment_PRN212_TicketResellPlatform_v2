using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class PolicyDAO
    {
        private PRN212_TicketResellPlatformContext context;

        private static PolicyDAO instance;

        public static PolicyDAO Instance
        {
            get =>  instance = instance ?? (instance = new PolicyDAO());    
        }

        private PolicyDAO() 
        {
            this.context = new PRN212_TicketResellPlatformContext();
        }

        public List<Policy> GetPolicies()
        {
            List<Policy> policies = context.Policies.ToList();
            foreach (var item in policies)
            {
                item.TypePolicy = TypePolicyDAO.Instance.GetTypePolicyByid(item.Id);
            }
            return policies;
        }

        public List<Policy> Search(string query) {
            List<Policy> policies = GetPolicies();
            List<Policy> result = new List<Policy>();
            string str = query.ToLower();
            foreach (var item in policies) {
                if (item.Id.ToString().Equals(str) || item.TypePolicy.Name.ToLower().Equals(str) || item.Content.ToLower().Equals(str)
                    || item.Fee.ToString().Equals(str))
                {
                    result.Add(item);
                }
            }
            return result;
        }

       
    }
}
