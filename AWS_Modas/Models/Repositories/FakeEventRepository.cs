using System;
using System.Collections.Generic;
using System.Linq;
using AWS_Modas.Models.Objects;

namespace AWS_Modas.Models.Repositories
{
    public class FakeEventRepository : IEventRepository
    {
        public IQueryable<Event> Events => new List<Event>
        {
            new Event
            {
                TimeStamp = new DateTime(2018, 4, 19, 1, 33, 32), Flagged = false,
                Location = Locations.FirstOrDefault(l => l.LocationId == 1)
            },
            new Event
            {
                TimeStamp = new DateTime(2018, 4, 19, 11, 28, 12), Flagged = false,
                Location = Locations.FirstOrDefault(l => l.LocationId == 3)
            },
            new Event
            {
                TimeStamp = new DateTime(2018, 4, 19, 18, 12, 56), Flagged = false,
                Location = Locations.FirstOrDefault(l => l.LocationId == 3)
            },
            new Event
            {
                TimeStamp = new DateTime(2018, 4, 21, 4, 26, 12), Flagged = false,
                Location = Locations.FirstOrDefault(l => l.LocationId == 2)
            },
            new Event
            {
                TimeStamp = new DateTime(2018, 4, 21, 8, 11, 34), Flagged = false,
                Location = Locations.FirstOrDefault(l => l.LocationId == 2)
            },
            new Event
            {
                TimeStamp = new DateTime(2018, 4, 23, 19, 5, 21), Flagged = false,
                Location = Locations.FirstOrDefault(l => l.LocationId == 1)
            },
            new Event
            {
                TimeStamp = new DateTime(2018, 4, 24, 8, 43, 6), Flagged = false,
                Location = Locations.FirstOrDefault(l => l.LocationId == 1)
            },
            new Event
            {
                TimeStamp = new DateTime(2018, 4, 24, 11, 56, 39), Flagged = false,
                Location = Locations.FirstOrDefault(l => l.LocationId == 2)
            },
            new Event
            {
                TimeStamp = new DateTime(2018, 4, 24, 20, 12, 18), Flagged = false,
                Location = Locations.FirstOrDefault(l => l.LocationId == 1)
            },
            new Event
            {
                TimeStamp = new DateTime(2018, 4, 25, 18, 9, 12), Flagged = false,
                Location = Locations.FirstOrDefault(l => l.LocationId == 1)
            },
            new Event
            {
                TimeStamp = new DateTime(2018, 4, 25, 19, 1, 2), Flagged = false,
                Location = Locations.FirstOrDefault(l => l.LocationId == 2)
            },
            new Event
            {
                TimeStamp = new DateTime(2018, 4, 28, 5, 4, 40), Flagged = false,
                Location = Locations.FirstOrDefault(l => l.LocationId == 3)
            }
        }.AsQueryable<Event>();

        public IQueryable<Location> Locations => new List<Location>
        {
            new Location
            {
                LocationId = 1,
                Name = "Index"
            },
            new Location
            {
                LocationId = 2,
                Name = "Event Horizon"
            },
            new Location
            {
                LocationId = 3,
                Name = "Dead End"
            }
        }.AsQueryable();
    }
}