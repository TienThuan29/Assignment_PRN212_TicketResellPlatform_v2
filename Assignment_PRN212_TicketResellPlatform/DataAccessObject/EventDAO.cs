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

        public bool UpdateEvent(Event Event)
        {
            bool isSuccess = false;
            Event updateEvent = GetEvent(Event.Id);
            if (updateEvent != null)
            {
                updateEvent.Detail = Event.Detail;
                updateEvent.Name = Event.Name;
                updateEvent.StartDate = Event.StartDate;
                updateEvent.EndDate = Event.EndDate;
                updateEvent.Image = Event.Image;

                context.Entry(updateEvent).State
                    = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            return isSuccess;
        }
    }
}
