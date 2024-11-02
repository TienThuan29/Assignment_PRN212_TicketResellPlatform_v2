using BusinessObject;
using DataAccessObject;
using Repository.Def;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Impl
{
    public class TicketRepository : ITicketRepository
    {
        public ICollection<Ticket> FindByGenericTicketID(long genericTicketID)
        {
            return TicketDAO.Instance.FindByGenericTicketID(genericTicketID);
        }

        public bool AddTicket(BusinessObject.Ticket ticket)
        {
            return TicketDAO.Instance.AddTicket(ticket);    
        }

        public ICollection<Ticket> FindByRequestSellingGenericTicket(long genericTicketID)
        {
            return TicketDAO.Instance.FindByRequestSellingGenericTicket(genericTicketID);
        }

        public bool AcceptTicketSelling(long ticketId)
        {
            return TicketDAO.Instance.AcceptTicketSelling(ticketId);
        }

        public bool RejectTicketSelling(long ticketId)
        {
            return TicketDAO.Instance.RejectTicketSelling(ticketId);
        }
    }
}
