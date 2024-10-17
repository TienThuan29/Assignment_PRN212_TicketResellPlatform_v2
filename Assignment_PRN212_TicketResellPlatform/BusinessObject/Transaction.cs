using System;
using System.Collections.Generic;

namespace BusinessObject
{
    public partial class Transaction
    {
        public long Id { get; set; }
        public long Amount { get; set; }
        public bool IsDone { get; set; }
        public DateTime TransDate { get; set; }
        public string? TransType { get; set; }
        public long? UserId { get; set; }
        public string? TransactionNo { get; set; }
    }
}
