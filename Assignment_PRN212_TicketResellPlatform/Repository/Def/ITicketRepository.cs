using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Def
{
    public interface ITicketRepository
    {
        ICollection<Ticket> FindByGenericTicketID(long genericTicketID);

        public bool AddTicket(BusinessObject.Ticket ticket);

        ICollection<Ticket> FindByRequestSellingGenericTicket(long genericTicketID);

        bool AcceptTicketSelling(long ticketId);

        bool RejectTicketSelling(long ticketId);
        public BusinessObject.Ticket GetTicketById(long ticketID);

        public bool MarkBought(long ticketId);
    }
}
