using DataAccessObject;
using Repository.Def;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Impl
{
    public class OrderGenericTicketRepository : IOrderGenericTicketRepository
    {
        public bool OrderGenericTicket(long GenericTicketId, int quantity, BusinessObject.User user)
        {
            return OrderGenericTicketDAO.Instance.OrderGenericTicket(GenericTicketId, quantity, user);
        }

    }
}
