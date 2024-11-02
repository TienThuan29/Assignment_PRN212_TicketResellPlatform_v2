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

        public static OrderTicketDAO Instance
        {
            get => instance = instance ?? (instance = new OrderTicketDAO());    
        }

        private OrderTicketDAO() 
        {
            this.context = new PRN212_TicketResellPlatformContext();
        }

        public bool CreateOrderTicket(int Quantity, long BuyerId, long GenericTicketId, long GenericTicketPrice)
        {
            bool result = false;
            try
            {
                OrderTicket orderTicket = new OrderTicket();
                orderTicket.Quantity = Quantity;
                orderTicket.BuyerId = BuyerId;
                orderTicket.GenericTicketId = GenericTicketId;
                orderTicket.TotalPrice = Quantity * GenericTicketPrice;
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
    }
}
