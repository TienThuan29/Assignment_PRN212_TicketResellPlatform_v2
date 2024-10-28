using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.EventService
{
    public interface IEventService
    {
        BusinessObject.Event GetEvent(int id);

        ICollection<Event> GetAllEvents();
    }
}
