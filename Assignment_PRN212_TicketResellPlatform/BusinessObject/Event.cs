using System;
using System.Collections.Generic;

namespace BusinessObject
{
    public partial class Event
    {
        public int Id { get; set; }
        public string? Detail { get; set; }
        public DateTime EndDate { get; set; }
        public string? Image { get; set; }
        public bool? IsDeleted { get; set; }
        public string? Name { get; set; }
        public DateTime StartDate { get; set; }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
