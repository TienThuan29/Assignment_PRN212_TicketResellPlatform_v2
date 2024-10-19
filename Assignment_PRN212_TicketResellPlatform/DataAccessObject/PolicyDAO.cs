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
    }
}
