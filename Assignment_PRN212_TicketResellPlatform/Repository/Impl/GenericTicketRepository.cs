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

        public ICollection<GenericTicket> FindTicketByEventId(long ticketEventId)
        {
            return GenericTicketDAO.Instance.FindTicketByEventId(ticketEventId);
        }

        public GenericTicket FindTicketById(long ticketId)
        {
            return GenericTicketDAO.Instance.FindTicketById(ticketId);
        }
    }
}
