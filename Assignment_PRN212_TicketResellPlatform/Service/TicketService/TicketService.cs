using BusinessObject;
using Repository.Def;
using Repository.Impl;
using Service.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.TicketService
{
    public class TicketService : ITicketService
    {
        private ITicketRepository tickeRepository;  


        public TicketService()
        {
            this.tickeRepository = new TicketRepository();  
        }


        public ICollection<BusinessObject.Ticket> FindByGenericTicketID(long genericTicketID)
        {
            return tickeRepository.FindByGenericTicketID(genericTicketID);
        }

        public bool AddTicket(BusinessObject.Ticket ticket) 
        {
            return tickeRepository.AddTicket(ticket);   
        }

        public BusinessObject.Ticket GetTicketById(long ticketID) 
        {
            return tickeRepository.GetTicketById(ticketID);
        }

    }
}
