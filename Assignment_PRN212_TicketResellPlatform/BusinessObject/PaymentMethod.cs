using System;
using System.Collections.Generic;

namespace BusinessObject
{
    public partial class PaymentMethod
    {
        public long Id { get; set; }
        public bool? IsDeleted { get; set; }
        public string? Name { get; set; }
    }
}
