using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripSupp.WebAPI.Data;
using TripSupp.WebAPI.Models;

namespace TripSupp.WebAPI
{
    public class Seed
    {
        private readonly DataContext _context;

        public Seed(DataContext context)
        {
            _context = context;
        }
        public void SeedDataContext()
        {
            var destinations = new List<Destination>()
            {
                new Destination() {
                    DestinationId = Guid.NewGuid(),
                    Title = "Paris"
                },
                new Destination() {
                    DestinationId = Guid.NewGuid(),
                    Title = "London"
                },
                new Destination() {
                    DestinationId = Guid.NewGuid(),
                    Title = "New York"
                },
                new Destination() {
                    DestinationId = Guid.NewGuid(),
                    Title = "Tokyo"
                },
                new Destination() {
                    DestinationId = Guid.NewGuid(),
                    Title = "Moscow"
                },
                new Destination() {
                    DestinationId = Guid.NewGuid(),
                    Title = "Berlin"
                },
                new Destination() {
                    DestinationId = Guid.NewGuid(),
                    Title = "Madrid"
                },
            };
            _context.Destinations.AddRange();
            _context.SaveChanges();
        }

    }
}