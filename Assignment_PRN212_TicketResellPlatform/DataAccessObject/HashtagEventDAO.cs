using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class HashtagEventDAO
    {
        private PRN212_TicketResellPlatformContext context;

        private static HashtagEventDAO instance;

        public static HashtagEventDAO Instance
        {
            get => instance = instance ?? (instance = new HashtagEventDAO());
        }

        private HashtagEventDAO()
        {
            this.context = new PRN212_TicketResellPlatformContext();
        }
    }
}
