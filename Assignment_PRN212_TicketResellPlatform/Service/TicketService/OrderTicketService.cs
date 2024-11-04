using BusinessObject;
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

        public ICollection<OrderTicket> GetAllOrderTicketsBySeller(long sellerId)
        {
            return orderTicketRepository.GetAllOrderTicketsBySeller(sellerId);
        }

        public bool OrderTicket(long GenericTicketId, int quantity, BusinessObject.User user)
        {
            return orderTicketRepository.OrderTicket(GenericTicketId, quantity, user);
        }

        public ICollection<OrderTicket> GetAllOrderTicketsByBuyer(long buyerId)
        {
            return orderTicketRepository.GetAllOrderTicketsByBuyer(buyerId);
        }

        public bool RejectOrder(string orderNo, string note)
        {
            return orderTicketRepository.RejectOrder(orderNo, note);
        }

        public OrderTicket GetOrderTicketByOrderNo(string orderNo)
        {
            return orderTicketRepository.GetOrderTicketByOrderNo(orderNo);
        }

        public void UpdateOrderTicket(OrderTicket orderTicket) 
        {
            orderTicketRepository.UpdateOrderTicket(orderTicket);
        }
    }
}
