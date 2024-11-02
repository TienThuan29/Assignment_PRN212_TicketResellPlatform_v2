using DataAccessObject;
using Repository.Def;
using Repository.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.TicketService
{
    public class OrderGenericTicketServicecs : IOrderGenericTicketService
    {
        private IOrderGenericTicketRepository orderGenericTicketRepository;

        public OrderGenericTicketServicecs() 
        {
            this.orderGenericTicketRepository = new OrderGenericTicketRepository();
        }
        public bool OrderGenericTicket(long GenericTicketId, int quantity, BusinessObject.User user)
        {
            return orderGenericTicketRepository.OrderGenericTicket(GenericTicketId, quantity, user);
        }
    }
}
