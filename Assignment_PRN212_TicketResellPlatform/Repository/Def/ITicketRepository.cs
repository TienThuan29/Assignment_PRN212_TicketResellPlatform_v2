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

        bool AcceptTicketSelling(long ticketId, long staffId, string note);

        bool RejectTicketSelling(long ticketId, long staffId, string note);
        public BusinessObject.Ticket GetTicketById(long ticketID);

        public ICollection<Ticket> FindSellingTicket(long genericTicketID);

        public bool MarkBought(long ticketId);

        public void UpdateBoughtTicket(Ticket ticket);

    }
}
