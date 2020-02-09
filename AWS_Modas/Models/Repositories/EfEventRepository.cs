using AWS_Modas.Models.Database;
using AWS_Modas.Models.Objects;
using System.Linq;

namespace AWS_Modas.Models.Repositories
{
    public class EfEventRepository : IEventRepository
    {
        private readonly AppDbContext _context;

        public EfEventRepository(AppDbContext ctx) => _context = ctx;

        public IQueryable<Event> Events => _context.Events;
        public IQueryable<Location> Locations => _context.Locations;

        public Event AddEvent(Event evt)
        {
            _context.Add(evt);
            _context.SaveChanges();
            return evt;
        }

        public Event UpdateEvent(Event source)
        {
            var target = _context.Events.FirstOrDefault(e => e.EventId == source.EventId);
            if (target is null) return null;

            target.TimeStamp = source.TimeStamp;
            target.Flagged = source.Flagged;
            target.LocationId = source.LocationId;
            _context.SaveChanges();
            return target;
        }

        
        public void DeleteEvent(int eventId)
        {
            var evt = _context.Events.FirstOrDefault(e => e.EventId == eventId);
            if (evt is null) return;

            _context.Events.Remove(evt);
            _context.SaveChanges();
        }
    }
}