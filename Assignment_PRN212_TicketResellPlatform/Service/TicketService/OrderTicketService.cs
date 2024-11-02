using Repository.Def;
using Repository.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.TicketService
{
    public class OrderTicketService : IOrderTicketService
    {
        private readonly IOrderTicketRepository orderTicketRepository;

        public OrderTicketService()
        {
            orderTicketRepository = new OrderTicketRepository();
        }
        public bool OrderTicket(long GenericTicketId, int quantity, BusinessObject.User user)
        {
            return orderTicketRepository.OrderTicket(GenericTicketId, quantity, user);
        }
    }
}
