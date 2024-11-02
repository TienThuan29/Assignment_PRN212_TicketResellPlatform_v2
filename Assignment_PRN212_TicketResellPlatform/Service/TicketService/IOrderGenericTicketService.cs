using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.TicketService
{
    public interface IOrderGenericTicketService
    {
        public bool OrderGenericTicket(long GenericTicketId, int quantity, BusinessObject.User user);
    }
}
