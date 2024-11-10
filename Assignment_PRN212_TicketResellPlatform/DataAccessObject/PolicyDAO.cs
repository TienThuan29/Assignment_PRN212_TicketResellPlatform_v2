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
                long? id = item.TypePolicyId;
                item.TypePolicy = TypePolicyDAO.Instance.GetTypePolicyByid(id);
            }
            return policies;
        }

        public List<Policy> Search(string query) {
            List<Policy> policies = GetPolicies();
            List<Policy> result = new List<Policy>();
            string str = query.ToLower();
            foreach (var item in policies) {
                if (item.Id.ToString().Contains(str)|| item.TypePolicy.Name.ToLower().Contains(str) || item.Content.ToLower().Contains(str)
                    || item.Fee.ToString().Contains(str))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public Policy GetPolicy(int id) {
            return context.Policies.SingleOrDefault(x => x.Id == id);
        }

        public bool AddPolicy(Policy policy) {
            bool isSuccess = false;
            try
            {
                context.Policies.Add(policy);
                context.SaveChanges();
                isSuccess = true;
            }
            catch (Exception ex) {
                isSuccess = false;
                Console.WriteLine(ex.Message);
            }

            return isSuccess;
        }
        
        public bool ChangeEnableOfPolicy(string id)
        {
            bool isSuccess = false;
            try
            {
                Policy policy = context.Policies.SingleOrDefault(x=>x.Id.ToString().Equals(id));
                if (policy != null)
                {
                    policy.IsDeleted = !policy.IsDeleted;
                    context.Policies.Update(policy);
                    context.SaveChanges();
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                isSuccess = false;
            }
            return isSuccess;
        }
    }
}
