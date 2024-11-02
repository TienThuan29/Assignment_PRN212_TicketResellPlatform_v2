using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Def
{
    public interface IGenericTicketRepository
    {
        ICollection<GenericTicket> FindBySellerId(long sellerId);

        public ICollection<GenericTicket> FindGenericTicketByEventId(long ticketEventId);
        public bool AddGenericTicket(GenericTicket ticket);

        public GenericTicket FindGenericTicketById(long ticketId);
    }
}
