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
    public class GenericTicketService : IGenericTicketService
    {
        private IGenericTicketRepository genericTicketRepository;

        public GenericTicketService() 
        {
            this.genericTicketRepository = new GenericTicketRepository();
        }

        public ICollection<GenericTicket> FindBySellerId(long sellerId)
        {
            return genericTicketRepository.FindBySellerId(sellerId);
        }

        public bool AddGenericTicket(GenericTicket genericTicket)
        {
            return genericTicketRepository.AddGenericTicket(genericTicket);
        }

        public ICollection<GenericTicket> FindTicketByEventId(long ticketEventId)
        {
            return genericTicketRepository.FindTicketByEventId(ticketEventId);
        }

        public GenericTicket FindGenericTicketById(long ticketId)
        {
            return genericTicketRepository.FindGenericTicketById(ticketId);
        }

        public ICollection<GenericTicket> GetRequestSellingGenericTickets()
        {
            return genericTicketRepository.GetRequestSellingGenericTickets();
        }

        public GenericTicket FindTicketById(long ticketId)
        {
            return genericTicketRepository.FindTicketById((int)ticketId);
        }
    }
}
