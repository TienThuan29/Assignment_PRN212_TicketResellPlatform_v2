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
        private readonly BusinessObject.User loggedUser;

        public static OrderGenericTicketDAO Instance
        {
            get => instance = instance ?? (instance = new OrderGenericTicketDAO());
        }

        private OrderGenericTicketDAO()
        {
            this.context = new PRN212_TicketResellPlatformContext();
        }

        private OrderGenericTicketDAO(BusinessObject.User user)
        {
            this.context = new PRN212_TicketResellPlatformContext();
            loggedUser = user;
        }

        public bool OrderGenericTicket( long GenericTicketId, int quantity)
        {
            bool isSuccess = false;
            GenericTicket genericTicket = GenericTicketDAO.Instance.FindTicketById(GenericTicketId);
            if(loggedUser.Balance >= genericTicket.Price* quantity)
            {
                OrderTicketDAO.Instance.CreateOrderTicket(quantity, loggedUser.Id, GenericTicketId, genericTicket.Price);
                loggedUser.Balance = loggedUser.Balance - genericTicket.Price*quantity;
                isSuccess = true;
            }
            return isSuccess;
        }
    }
}
