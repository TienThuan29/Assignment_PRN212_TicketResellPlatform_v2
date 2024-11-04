using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class OrderGenericTicketDAO
    {
        private PRN212_TicketResellPlatformContext context;
        private static OrderGenericTicketDAO instance;

        public static OrderGenericTicketDAO Instance
        {
            get => instance = instance ?? (instance = new OrderGenericTicketDAO());
        }

        private OrderGenericTicketDAO()
        {
            this.context = new PRN212_TicketResellPlatformContext();
        }


        public bool OrderGenericTicket( long GenericTicketId, int quantity, BusinessObject.User user)
        {
            bool isSuccess = false;
            GenericTicket genericTicket = GenericTicketDAO.Instance.FindGenericTicketById(GenericTicketId);
            if(user.Balance >= genericTicket.Price* quantity && quantity > 0)
            {
                OrderTicketDAO.Instance.CreateOrderTicket(quantity, user.Id, GenericTicketId, genericTicket.Price);
                user.Balance = user.Balance - genericTicket.Price*quantity;
                isSuccess = true;
            } 
            return isSuccess;
        }
    }
}
