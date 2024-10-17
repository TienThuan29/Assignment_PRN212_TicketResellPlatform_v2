using System;
using System.Collections.Generic;

namespace BusinessObject
{
    public partial class Staff
    {
        public long Id { get; set; }
        public byte[]? Avatar { get; set; }
        public long? Balance { get; set; }
        public string Email { get; set; } = null!;
        public string? Firstname { get; set; }
        public bool? IsEnable { get; set; }
        public string? Lastname { get; set; }
        public string Password { get; set; } = null!;
        public string? Phone { get; set; }
        public long? Revenue { get; set; }
        public string? RoleCode { get; set; }
        public string StaffCode { get; set; } = null!;
        public string? Username { get; set; }
    }
}
