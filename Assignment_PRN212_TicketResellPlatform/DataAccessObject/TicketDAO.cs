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


        public bool AddTicket(BusinessObject.Ticket ticket)
        {
            bool flag = true;
            try
            {
                context.Tickets.Add(ticket);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                flag = false;
            }
            return flag;
        }

        public Ticket GetTicketById(long ticketID) 
        {
            return context.Tickets.SingleOrDefault(ticket => ticket.Id.Equals(ticketID));
        }

        public bool MarkBought(long ticketId)
        {
            bool flag = true;
            try
            {
                Ticket ticket = GetTicketById(ticketId);
                if (ticket != null)
                {
                    ticket.IsBought = true;
                    ticket.Process = GeneralProcess.SUCCESS;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                flag = false;
            }
            return flag;
        }
    }
}
