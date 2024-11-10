using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public partial class EventRevenue
    {
        public string EventName { get; set; }
        public int TicketCount { get; set; }
        public DateTime StartDate { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
