using System;
using System.Collections.Generic;

namespace BusinessObject
{
    public partial class Policy
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public int Fee { get; set; }
        public bool? IsDeleted { get; set; }
        public long? TypePolicyId { get; set; }
    }
}
