using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.TicketService
{
    public interface IOrderTicketService
    {
        public bool OrderTicket(long GenericTicketId, int quantity, BusinessObject.User user);

        public ICollection<OrderTicket> GetAllOrderTicketsBySeller(long sellerId);

        public ICollection<OrderTicket> GetAllOrderTicketsByBuyer(long buyerId);
    }
}
