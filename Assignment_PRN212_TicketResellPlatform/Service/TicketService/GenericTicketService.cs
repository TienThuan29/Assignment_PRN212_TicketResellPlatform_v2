﻿using BusinessObject;
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

        private ICategoryRepository categoryRepository;

        private IEventRepository eventRepository;

        public GenericTicketService() 
        {
            this.genericTicketRepository = new GenericTicketRepository();
            this.categoryRepository = new CategoryRepository();
            this.eventRepository = new EventRepository();
        }

        public ICollection<GenericTicket> FindBySellerId(long sellerId)
        {
            return genericTicketRepository.FindBySellerId(sellerId);
        }

        public bool AddGenericTicket(GenericTicket genericTicket)
        {
            return genericTicketRepository.AddGenericTicket(genericTicket);
        }

        public ICollection<GenericTicket> FindGenericTicketByEventId(long ticketEventId)
        {
            return genericTicketRepository.FindGenericTicketByEventId(ticketEventId);
        }

        public GenericTicket FindGenericTicketById(long ticketId)
        {
            return genericTicketRepository.FindGenericTicketById(ticketId);
        }

        public ICollection<GenericTicket> GetRequestSellingGenericTickets()
        {
            var genericTickets = genericTicketRepository.GetRequestSellingGenericTickets();
            foreach (var genericTicket in genericTickets) {
                if (genericTicket.CategoryId != null && genericTicket.EventId != null)
                {
                    genericTicket.Category = categoryRepository.GetCategoryById(genericTicket.CategoryId.Value);
                    genericTicket.Event = eventRepository.GetEvent(genericTicket.EventId.Value);
                }
            }
            return genericTickets;
        }

        public GenericTicket FindTicketById(long ticketId)
        {
            return genericTicketRepository.FindTicketById((int)ticketId);
        }
    }
}
