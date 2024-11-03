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

        public BusinessObject.Ticket GetTicketById(long ticketID);

        public ICollection<BusinessObject.Ticket> FindSellingTicket(long genericTicketID);


        ICollection<Ticket> FindByRequestSellingGenericTicket(long genericTicketID);

        bool AcceptTicketSelling(long ticketId, long staffId, string note);

        bool RejectTicketSelling(long ticketId, long staffId, string note);

        public bool MarkBought(long ticketId);

    }
}
