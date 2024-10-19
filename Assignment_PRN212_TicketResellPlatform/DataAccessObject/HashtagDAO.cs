using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class HashtagDAO
    {
        private PRN212_TicketResellPlatformContext context;

        private static HashtagDAO instance;

        public static HashtagDAO Instance
        {
            get => instance = instance ?? (instance = new HashtagDAO());    
        }

        private HashtagDAO() 
        {
            this.context = new PRN212_TicketResellPlatformContext();
        }
    }
}
