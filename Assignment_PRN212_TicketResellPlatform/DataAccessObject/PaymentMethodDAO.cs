using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class PaymentMethodDAO
    {
        private PRN212_TicketResellPlatformContext context;

        private static PaymentMethodDAO instance;   

        public static PaymentMethodDAO Instance
        {
            get => instance = instance ?? (instance = new PaymentMethodDAO());  
        }

        private PaymentMethodDAO()
        {
            this.context = new PRN212_TicketResellPlatformContext();
        }  
    }
}
