using BusinessObject;
using DataAccessObject;
using Repository.Def;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Impl
{
    public class OrderTicketRepository : IOrderTicketRepository
    {
        public bool CreateOrderTicket(int Quantity, long BuyerId, long GenericTicketId, long GenericTicketPrice)
        {
            return OrderTicketDAO.Instance.CreateOrderTicket(Quantity, BuyerId, GenericTicketId, GenericTicketPrice);  
        }

        public bool OrderTicket(long GenericTicketId, int quantity, User user)
        {
            return OrderTicketDAO.Instance.OrderTicket(GenericTicketId, quantity, user);
        }

        public ICollection<OrderTicket> GetAllOrderTicketsBySeller(long sellerId)
        {
            return OrderTicketDAO.Instance.GetAllOrderTicketsBySeller(sellerId);
        }

        public ICollection<OrderTicket> GetAllOrderTicketsByBuyer(long buyerId)
        {
            return OrderTicketDAO.Instance.GetAllOrderTicketsByBuyer(buyerId);
        }

        public bool RejectOrder(string orderNo, string note)
        {
            return OrderTicketDAO.Instance.RejectOrder(orderNo, note);
        }

        public OrderTicket GetOrderTicketByOrderNo(string orderNo)
        {
            return OrderTicketDAO.Instance.GetOrderTicketByOrderNo(orderNo);
        }

        public void UpdateOrderTicket(OrderTicket orderTicket)
        {
            OrderTicketDAO.Instance.UpdateOrderTicket(orderTicket);
        }
    }
}
