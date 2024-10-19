using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class EventDAO
    {
        private PRN212_TicketResellPlatformContext context;

        private static EventDAO instance;   

        public static EventDAO Instance
        {
            get => instance = instance ?? (instance = new EventDAO());
        }

        private EventDAO() 
        { 
            this.context = new PRN212_TicketResellPlatformContext();
        }
    }
}
