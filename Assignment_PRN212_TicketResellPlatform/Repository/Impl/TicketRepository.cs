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

        public BusinessObject.Ticket GetTicketById(long ticketID)
        {
            return TicketDAO.Instance.GetTicketById(ticketID);
        }


        public ICollection<Ticket> FindSellingTicket(long genericTicketID)
        {
            return TicketDAO.Instance.FindSellingTicket(genericTicketID);
        }
        public bool MarkBought(long ticketId)
        {
            return TicketDAO.Instance.MarkBought(ticketId);

        }

        public bool AcceptTicketSelling(long ticketId, long staffId, string note)
        {
            return TicketDAO.Instance.AcceptTicketSelling(ticketId, staffId, note);
        }

        public bool RejectTicketSelling(long ticketId, long staffId, string note)
        {
            return TicketDAO.Instance.RejectTicketSelling(ticketId, staffId, note);
        }

        public void UpdateBoughtTicket(Ticket ticket)
        {
            TicketDAO.Instance.UpdateBoughtTicket(ticket);
        }
    }
}
