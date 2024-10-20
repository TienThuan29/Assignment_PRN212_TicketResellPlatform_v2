using System;
using System.Collections.Generic;

namespace BusinessObject
{
    public partial class Ticket
    {
        public long Id { get; set; }
        public DateTime? BoughtDate { get; set; }
        public long? BuyerId { get; set; }
        public byte[]? Image { get; set; }
        public bool? IsBought { get; set; }
        public bool? IsChecked { get; set; }
        public bool? IsValid { get; set; }
        public string? Note { get; set; }
        public string? Process { get; set; }
        public string TicketSerial { get; set; } = null!;
        public long? GenericTicketId { get; set; }
        public long? StaffId { get; set; }

    }
}
