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

        public ICollection<Ticket> FindByRequestSellingGenericTicket(long genericTicketID)
        {
            return this.context.Tickets.Where(ticket => ticket.GenericTicketId.Equals(genericTicketID)
                && ticket.Process.Equals(GeneralProcess.WAITING)
            ).ToList();
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

        public bool AcceptTicketSelling(long ticketId)
        {
            bool isSuccess = false;
            Ticket ticket = context.Tickets.SingleOrDefault(ticket => ticket.Id.Equals(ticketId));
            if (ticket != null) 
            {
                ticket.Process = GeneralProcess.SELLING;
                ticket.IsChecked = true;
                ticket.IsValid = true;
                //Save to db
                context.Entry(ticket).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        public bool RejectTicketSelling(long ticketId)
        {
            bool isSuccess = false;
            Ticket ticket = context.Tickets.SingleOrDefault(ticket => ticket.Id.Equals(ticketId));
            if (ticket != null)
            {
                ticket.Process = GeneralProcess.REJECTED;
                ticket.IsChecked = true;
                ticket.IsValid = false;

                //Save to db
                context.Entry(ticket).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }
    }
}
