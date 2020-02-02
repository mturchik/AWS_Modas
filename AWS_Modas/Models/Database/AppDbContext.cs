using AWS_Modas.Models.Objects;
using Microsoft.EntityFrameworkCore;

namespace AWS_Modas.Models.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Event> Events { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}