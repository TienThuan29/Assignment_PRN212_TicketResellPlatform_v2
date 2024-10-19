using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class GenericTicketDAO
    {
        private PRN212_TicketResellPlatformContext context;

        private static GenericTicketDAO instance;

        public static GenericTicketDAO Instance
        {
            get => instance = instance ?? (instance = new GenericTicketDAO());
        }

        private GenericTicketDAO() 
        { 
            this.context = new PRN212_TicketResellPlatformContext();
        }
    }
}
