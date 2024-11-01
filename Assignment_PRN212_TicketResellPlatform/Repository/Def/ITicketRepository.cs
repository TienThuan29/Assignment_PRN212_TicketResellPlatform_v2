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
    }
}
