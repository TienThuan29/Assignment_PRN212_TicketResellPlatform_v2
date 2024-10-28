using BusinessObject;
using Repository.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.EventService
{
    public class EventService : IEventService
    {
        private readonly EventRepository eventRepository;

        public EventService()
        {
            eventRepository = new EventRepository();
        }

        public ICollection<Event> GetAllEvents()
        {
            return eventRepository.GetAllEvents();
        }

        public Event GetEvent(int id)
        {
            return eventRepository.GetEvent(id);
        }
    }
}
