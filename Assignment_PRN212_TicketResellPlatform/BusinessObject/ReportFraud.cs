using System;
using System.Collections.Generic;

namespace BusinessObject
{
    public partial class ReportFraud
    {
        public long Id { get; set; }
        public string? Content { get; set; }
        public string? ReportProcess { get; set; }
        public string? Proof { get; set; }
        public long ReportedUserId { get; set; }
        public long StaffId { get; set; }
        public long? AccuserId { get; set; }
        public int? ReportTypeId { get; set; }
        public long? TicketId { get; set; }
        public string? Note { get; set; }
    }
}
