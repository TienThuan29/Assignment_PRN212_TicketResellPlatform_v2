﻿using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.TicketService
{
    public interface IGenericTicketService
    {
        ICollection<GenericTicket> FindBySellerId(long sellerId);
    }
}