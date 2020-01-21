using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace AWS_SeedData
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Running program...");
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
                        EventId = eventList.Count == 0 ? 1 : eventList.Last().EventId + 1,
                        TimeStamp = new DateTime(startDate.Year, startDate.Month, startDate.Day,
                            rand.Next(1, 24), rand.Next(0, 60), rand.Next(0, 60)),
                        Flagged = rand.Next(0, 2) == 1,
                        Location = locList.ElementAt(rand.Next(0, 3))
                    });
                }

                startDate = startDate.AddDays(1);
            }

            eventList.ForEach(e => e.LocationId = e.Location.LocationId);
            eventList.Sort((e1, e2) => e1.TimeStamp.CompareTo(e2.TimeStamp));
            eventList.ForEach(e => Console.WriteLine(JsonConvert.SerializeObject(e)));
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

        public class Location
        {
            public int LocationId { get; set; }
            public string Name { get; set; }
        }

        public class Event
        {
            public int EventId { get; set; }
            public DateTime TimeStamp { get; set; }
            public bool Flagged { get; set; }

            public int LocationId { get; set; }
            public Location Location { get; set; }
        }
    }
}
