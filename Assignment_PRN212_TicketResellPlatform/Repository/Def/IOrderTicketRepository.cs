using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Def
{
    public interface IOrderTicketRepository
    {
        public bool CreateOrderTicket(int Quantity, long BuyerId, long GenericTicketId, long GenericTicketPrice);
    }
}
