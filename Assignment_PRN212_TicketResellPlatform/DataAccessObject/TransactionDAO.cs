﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class TransactionDAO
    {
        private PRN212_TicketResellPlatformContext context;

        private static TransactionDAO instance;

        public static TransactionDAO Instance
        {
            get => instance = instance ?? (instance = new TransactionDAO());    
        }

        private TransactionDAO()
        {
            this.context = new PRN212_TicketResellPlatformContext();
        }
    }
}