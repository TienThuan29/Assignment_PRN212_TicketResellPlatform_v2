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

        public ICollection<Ticket> FindByRequestSellingGenericTicket(long genericTicketID)
        {
            return tickeRepository.FindByRequestSellingGenericTicket(genericTicketID);
        }

        public bool AcceptTicketSelling(long ticketId, long staffId, string note)
        {
            return tickeRepository.AcceptTicketSelling(ticketId, staffId, note);
        }

        public bool RejectTicketSelling(long ticketId, long staffId, string note)
        {
            return tickeRepository.RejectTicketSelling(ticketId, staffId, note);
        }
        public BusinessObject.Ticket GetTicketById(long ticketID) 
        {
            return tickeRepository.GetTicketById(ticketID);
        }

        public ICollection<BusinessObject.Ticket> FindSellingTicket(long genericTicketID)
        {
            return tickeRepository.FindSellingTicket(genericTicketID);
        }

        public bool MarkBought(long ticketId)
        {
            return tickeRepository.MarkBought(ticketId);
        }

        public void UpdateBoughtTicket(Ticket ticket)
        {
            tickeRepository.UpdateBoughtTicket(ticket);
        }
    }
}
