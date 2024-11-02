﻿using BusinessObject;
using DataAccessObject;
using Repository.Def;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Impl
{
    public class TicketRepository : ITicketRepository
    {
        public ICollection<Ticket> FindByGenericTicketID(long genericTicketID)
        {
            return TicketDAO.Instance.FindByGenericTicketID(genericTicketID);
        }

        public bool AddTicket(BusinessObject.Ticket ticket)
        {
            return TicketDAO.Instance.AddTicket(ticket);    
        }

        public BusinessObject.Ticket GetTicketById(long ticketID)
        {
            return TicketDAO.Instance.GetTicketById(ticketID);
        }

        public bool MarkBought(long ticketId)
        {
            return TicketDAO.Instance.MarkBought(ticketId);
        }
    }
}
