﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service.Ticket
{
    public interface ITicketService
    {
        ICollection<BusinessObject.Ticket> FindByGenericTicketID(long genericTicketID);

        public bool AddTicket(BusinessObject.Ticket ticket);

        public BusinessObject.Ticket GetTicketById(long ticketID);

        public ICollection<BusinessObject.Ticket> FindSellingTicket(long genericTicketID);
    }
}
