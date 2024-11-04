using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class OrderTicketDAO
    {
        private PRN212_TicketResellPlatformContext context;

        private static OrderTicketDAO instance;

        private static Random random = new Random();
        public static OrderTicketDAO Instance
        {
            get => instance = instance ?? (instance = new OrderTicketDAO());    
        }

        
        private OrderTicketDAO() 
        {
            this.context = new PRN212_TicketResellPlatformContext();
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public OrderTicket GetOrderTicketByOrderNo(string orderNo)
        {
            return context.OrderTickets.SingleOrDefault(obj => obj.OrderNo.Equals(orderNo));
        }

        public void UpdateOrderTicket(OrderTicket orderTicket)
        {
            context.Entry<OrderTicket>(orderTicket).CurrentValues.SetValues(orderTicket);
            context.SaveChanges();
        }

        public bool CreateOrderTicket(int Quantity, long BuyerId, long GenericTicketId, long GenericTicketPrice)
        {
            bool result = false;
            try
            {
                OrderTicket orderTicket = new OrderTicket();
                orderTicket.OrderNo = RandomString(10);
                orderTicket.IsAccepted = false;
                orderTicket.IsCanceled = false;
                orderTicket.Quantity = Quantity;
                orderTicket.BuyerId = BuyerId;
                orderTicket.GenericTicketId = GenericTicketId;
                orderTicket.TotalPrice = Quantity * GenericTicketPrice;
                orderTicket.Note = "";
                orderTicket.PaymentMethodId = 1;
                context.OrderTickets.Add(orderTicket);
                context.SaveChanges();
                result = true;
            }
            catch (Exception ex) 
            {
                result = false;
            }

            return result;
        }

        public bool RejectOrder(string orderNo, string note)
        {
            bool flag = true;
            try
            {
                OrderTicket orderTicket = GetOrderTicketByOrderNo(orderNo);
                
                if (orderTicket != null)
                {
                    orderTicket.Note = note;
                    orderTicket.IsAccepted = false;
                    context.Entry<OrderTicket>(orderTicket).CurrentValues.SetValues(orderTicket);
                    context.SaveChanges();
                    // Refund for buyer
                    User user = UserDAO.Instance.FindById(orderTicket.BuyerId);
                    user.Balance += orderTicket.TotalPrice;
                    UserDAO.Instance.SaveProfile(user);

                    context.SaveChanges();
                }
                else flag = false;

            }
            catch (Exception ex)
            {
                flag = false;
            }
            return flag;
        }

        public bool AcceptOrder(string orderNo) 
        {
            return true;
        }


        public bool OrderTicket(long GenericTicketId, int quantity, BusinessObject.User user)
        {
            bool isSuccess = false;
            GenericTicket genericTicket = GenericTicketDAO.Instance.FindGenericTicketById(GenericTicketId);
            if (user.Balance >= genericTicket.Price * quantity && quantity > 0)
            {
                if(CreateOrderTicket(quantity, user.Id, GenericTicketId, genericTicket.Price))
                {
                    user.Balance = user.Balance - genericTicket.Price * quantity;
                    UserDAO.Instance.SaveProfile(user);
                    context.SaveChanges();
                    isSuccess = true;
                }

            }
            return isSuccess;
        }

        public ICollection<OrderTicket> GetAllOrderTicketsBySeller(long sellerId)
        {
            var orderTickets = (from ot in context.OrderTickets 
                                join gt in context.GenericTickets
                                on ot.GenericTicketId equals gt.Id
                                where gt.SellerId == sellerId 
                                select ot)
                                .ToList();
            return orderTickets;
;       }

        public ICollection<OrderTicket> GetAllOrderTicketsByBuyer(long buyerId)
        {
            return context.OrderTickets.Where(orderTicket => orderTicket.BuyerId.Equals(buyerId)).ToList(); 
        }
    }
}
