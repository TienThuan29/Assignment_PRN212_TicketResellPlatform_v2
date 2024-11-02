using BusinessObject;
using DataAccessObject;
using Repository.Def;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Impl
{
    public class EventRepository : IEventRepository
    {
        public bool CreateEvent(Event Event)
        {
            return EventDAO.Instance.CreateEvent(Event);
        }

        public ICollection<Event> GetAllEvents()
        {
            return EventDAO.Instance.GetAllEvents();
        }

        public Event GetEvent(int id)
        {
            return EventDAO.Instance.GetEvent(id);
        }

        public bool UpdateEvent(Event Event)
        {
            return EventDAO.Instance.UpdateEvent(Event);
        }
    }
}
