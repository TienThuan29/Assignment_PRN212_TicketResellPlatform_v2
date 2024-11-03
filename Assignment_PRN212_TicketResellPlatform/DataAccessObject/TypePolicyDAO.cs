using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class TypePolicyDAO
    {
        private PRN212_TicketResellPlatformContext context;

        private static TypePolicyDAO instance;

        public static TypePolicyDAO Instance
        {
            get => instance = instance ?? (instance = new TypePolicyDAO()); 
        }

        private TypePolicyDAO()
        {
            this.context = new PRN212_TicketResellPlatformContext();
        }

        public TypePolicy GetTypePolicyByid(long id)
        {
            return this.context.TypePolicies.SingleOrDefault(m => m.Id.Equals(id));
        }
    }
}
