using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.TicketService
{
    public interface IGenericTicketService
    {
        ICollection<GenericTicket> FindBySellerId(long sellerId);

        public bool AddGenericTicket(GenericTicket ticket);

        public ICollection<GenericTicket> FindGenericTicketByEventId(long ticketEventId);

        public GenericTicket FindTicketById(long ticketId);

        ICollection<GenericTicket> GetRequestSellingGenericTickets();

        public GenericTicket FindGenericTicketById(long ticketId);
    }
}
