﻿using Repository.Def;
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
    }
}
