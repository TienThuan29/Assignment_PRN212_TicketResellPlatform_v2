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
    public class GenericTicketRepository : IGenericTicketRepository
    {
        public ICollection<GenericTicket> FindBySellerId(long sellerId)
        {
            return GenericTicketDAO.Instance.FindBySellerId(sellerId);
        }

        public bool AddGenericTicket(GenericTicket ticket)
        {
            return GenericTicketDAO.Instance.AddGenericTicket(ticket);
        }

        public ICollection<GenericTicket> FindGenericTicketByEventId(long ticketEventId)
        {
            return GenericTicketDAO.Instance.FindGenericTicketByEventId(ticketEventId);
        }

        public GenericTicket FindGenericTicketById(long ticketId)
        {
            return GenericTicketDAO.Instance.FindGenericTicketById(ticketId);
        }

        public ICollection<GenericTicket> GetRequestSellingGenericTickets()
        {
            return GenericTicketDAO.Instance.GetRequestSellingGenericTickets();
        }

        public GenericTicket FindTicketById(long ticketId)
        {
            throw new NotImplementedException();
        }
    }
}
