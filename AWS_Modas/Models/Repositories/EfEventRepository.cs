using System.Linq;
using AWS_Modas.Models.Database;
using AWS_Modas.Models.Objects;
using Microsoft.EntityFrameworkCore;

namespace AWS_Modas.Models.Repositories
{
    public class EfEventRepository : IEventRepository
    {
        private readonly AppDbContext _context;

        public EfEventRepository(AppDbContext ctx) => _context = ctx;

        public IQueryable<Event> Events => _context.Events;
        public IQueryable<Location> Locations => _context.Locations;
    }
}