﻿using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Def
{
    public interface IGenericTicketRepository
    {
        ICollection<GenericTicket> FindBySellerId(long sellerId);
    }
}
