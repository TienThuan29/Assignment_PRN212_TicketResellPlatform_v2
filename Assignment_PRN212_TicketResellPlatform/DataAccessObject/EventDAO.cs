using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class EventDAO
    {
        private PRN212_TicketResellPlatformContext context;

        private static EventDAO instance;   

        public static EventDAO Instance
        {
            get => instance = instance ?? (instance = new EventDAO());
        }

        private EventDAO() 
        { 
            this.context = new PRN212_TicketResellPlatformContext();
        }

        public ICollection<Event> GetAllEvents()
        {
            return context.Events.ToList();
        }

        public Event GetEvent(int id) 
        {
            return context.Events.SingleOrDefault(m => m.Id.Equals(id));
        }

        public bool CreateEvent(Event Event)
        {
            bool isSuccess = false;
            try
            {
                context.Events.Add(Event);
                context.SaveChanges();
                isSuccess = true;
            }
            catch (Exception ex)
            {
                isSuccess = false;
            }

            return isSuccess;
        }

        public bool UpdateEvent(Event updatedEvent)
        {
            bool isSuccess = false;
            Event existingEvent = GetEvent(updatedEvent.Id);

            if (existingEvent != null)
            {
                existingEvent.Detail = updatedEvent.Detail;
                existingEvent.Name = updatedEvent.Name;
                existingEvent.StartDate = updatedEvent.StartDate;
                existingEvent.EndDate = updatedEvent.EndDate;
                existingEvent.Image = updatedEvent.Image;

                context.Entry(existingEvent).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();

                isSuccess = true;
            }

            return isSuccess;
        }

        public ICollection<Event> SearchEventsByName(string eventName)
        {
            if (string.IsNullOrWhiteSpace(eventName))
            {
                return GetAllEvents();
            }
            var matchingEvents = context.Events
                .Where(e => e.Name.Contains(eventName)) 
                .ToList();

            return matchingEvents;
        }
    }
}
