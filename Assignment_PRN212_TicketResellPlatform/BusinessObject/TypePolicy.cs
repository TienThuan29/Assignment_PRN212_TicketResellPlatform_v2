using System;
using System.Collections.Generic;

namespace BusinessObject
{
    public partial class TypePolicy
    {
        public long Id { get; set; }
        public bool? IsDeleted { get; set; }
        public string? Name { get; set; }
    }
}
