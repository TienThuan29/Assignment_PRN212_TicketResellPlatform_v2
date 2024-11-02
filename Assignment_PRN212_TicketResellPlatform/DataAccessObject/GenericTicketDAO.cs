using BusinessObject;
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


        public ICollection<GenericTicket> FindBySellerId(long sellerId)
        {
            return this.context.GenericTickets.Where(gt => gt.SellerId.Equals(sellerId)).ToList();
        }

        public ICollection<GenericTicket> FindGenericTicketByEventId(long ticketEventId) 
        {
            return this.context.GenericTickets.Where(a => a.EventId.Equals((int)ticketEventId)).ToList();
        }

        public GenericTicket FindGenericTicketById(long ticketId) 
        {
            return this.context.GenericTickets.SingleOrDefault(a => a.Id.Equals(ticketId));
        }



        public bool AddGenericTicket(GenericTicket genericTicket)
        {
            bool flag = true;
            try
            {
                context.GenericTickets.Add(genericTicket);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                flag = false;
            }
            return flag;
        }

        public ICollection<GenericTicket> GetRequestSellingGenericTickets()
        {
            var genericTickets = (from gt in context.GenericTickets
                                  join t in context.Tickets on gt.Id equals t.GenericTicketId
                                  where t.Process == GeneralProcess.WAITING
                                  select gt
                                  ).Distinct();
            
            return (ICollection<GenericTicket>)genericTickets;
        }
    }
}
