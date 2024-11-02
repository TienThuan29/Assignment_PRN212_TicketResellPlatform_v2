using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Def
{
    public interface IEventRepository
    {
        ICollection<Event> GetAllEvents();

        Event GetEvent(int id);

        bool CreateEvent(Event Event);

        bool UpdateEvent(Event Event);

        ICollection<Event> SearchEventsByName(string name);
    }
}
