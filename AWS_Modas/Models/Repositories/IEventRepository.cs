using System.Linq;
using AWS_Modas.Models.Objects;

namespace AWS_Modas.Models.Repositories
{
    public interface IEventRepository
    {
        IQueryable<Event> Events { get; }
        IQueryable<Location> Locations { get; }
        Event AddEvent(Event evt);
        Event UpdateEvent(Event source);
        void DeleteEvent(int eventId);
    }
}