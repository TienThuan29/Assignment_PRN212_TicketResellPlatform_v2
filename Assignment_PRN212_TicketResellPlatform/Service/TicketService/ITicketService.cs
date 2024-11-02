using BusinessObject;
using DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service.TicketService
{
    public interface ITicketService
    {
        ICollection<BusinessObject.Ticket> FindByGenericTicketID(long genericTicketID);

        public bool AddTicket(BusinessObject.Ticket ticket);

        ICollection<Ticket> FindByRequestSellingGenericTicket(long genericTicketID);

        bool AcceptTicketSelling(long ticketId);

        bool RejectTicketSelling(long ticketId);
    }
}
