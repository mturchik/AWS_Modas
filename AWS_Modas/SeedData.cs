using AWS_Modas.Models.Database;
using AWS_Modas.Models.Objects;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AWS_Modas
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetRequiredService<AppDbContext>();
            context.Database.Migrate();

            if (context.Events.Any()) return;

            var locList = MakeLocations();
            var eventList = new List<Event>();

            var currentDate = DateTime.Now;
            var startDate = currentDate.AddMonths(-6);
            var rand = new Random();

            while (startDate.CompareTo(currentDate) != 1)
            {
                for (var i = 0; i < rand.Next(0, 5); i++)
                {
                    eventList.Add(new Event
                    {
                        TimeStamp = new DateTime(startDate.Year, startDate.Month, startDate.Day,
                            rand.Next(1, 24), rand.Next(0, 60), rand.Next(0, 60)),
                        Flagged = rand.Next(0, 2) == 1,
                        Location = locList.ElementAt(rand.Next(0, 3))
                    });
                }

                startDate = startDate.AddDays(1);
            }

            eventList.ForEach(e => e.LocationId = e.Location.LocationId);
            eventList.Sort((e1, e2) => e1.TimeStamp.Value.CompareTo(e2.TimeStamp.Value));
            locList.ForEach(l => l.LocationId = 0);

            context.Locations.AddRange(locList);
            context.Events.AddRange(eventList);

            context.SaveChanges();
        }

        private static List<Location> MakeLocations() => new List<Location>
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
        };
    }
}