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
                if (item.IsDeleted.Equals(true))
                {
                    policies.Remove(item);
                }
            }
            return policies;
        }
    }
}
