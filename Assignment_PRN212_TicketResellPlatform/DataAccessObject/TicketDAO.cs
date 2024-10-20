using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class TicketDAO
    {
        private PRN212_TicketResellPlatformContext context;

        private static TicketDAO instance;

        public static TicketDAO Instance
        {
            get => instance = instance ?? (instance = new TicketDAO()); 
        }
        private TicketDAO()
        {
            this.context = new PRN212_TicketResellPlatformContext();
        } 


        public ICollection<Ticket> FindByGenericTicketID(long genericTicketID)
        {
            return this.context.Tickets.Where(ticket => ticket.GenericTicketId.Equals(genericTicketID)).ToList();
        }
    }
}
