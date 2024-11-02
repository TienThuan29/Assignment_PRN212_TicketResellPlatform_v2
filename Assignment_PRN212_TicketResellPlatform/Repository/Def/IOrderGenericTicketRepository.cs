using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Def
{
    public interface IOrderGenericTicketRepository
    {
        public bool OrderGenericTicket(long GenericTicketId, int quantity);
    }
}
