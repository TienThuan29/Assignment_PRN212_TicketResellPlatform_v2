using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class OrderTicketDAO
    {
        private PRN212_TicketResellPlatformContext context;

        private static OrderTicketDAO instance;

        public static OrderTicketDAO Instance
        {
            get => instance = instance ?? (instance = new OrderTicketDAO());    
        }

        private OrderTicketDAO() 
        {
            this.context = new PRN212_TicketResellPlatformContext();
        }
    }
}
