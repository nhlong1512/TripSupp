using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TripSupp.WebAPI.Data;
using TripSupp.WebAPI.Data.Models;
using TripSupp.WebAPI.Repositories.Interfaces;

namespace TripSupp.WebAPI.Repositories.Implementations
{
    public class DestinationRepository : IDestinationRepository
    {
        private readonly DataContext _context;

        public DestinationRepository(DataContext context)
        {
            _context = context;
        }

        public async ValueTask<ICollection<Destination>> GetAllDestinationsAsync()
        {
            ICollection<Destination> destinations = await _context.Destinations.ToListAsync();
            return destinations;
        }

        public async ValueTask<Destination> GetDestinationByIdAsync(Guid id)
        {
            Destination destination = await _context.Destinations.FirstOrDefaultAsync(x => x.DestinationId == id);
            return destination;
        }

        public async ValueTask<Destination> CreateDestinationAsync(Destination destination)
        {
            await _context.Destinations.AddAsync(destination);
            await _context.SaveChangesAsync();
            return destination;
        }

        public async ValueTask<Destination> UpdateDestinationAsync(Destination destination)
        {
            _context.Destinations.Update(destination);
            await _context.SaveChangesAsync();
            return destination;
        }

        public async ValueTask<bool> DeleteDestinationAsync(Guid id)
        {
            Destination destination = await _context.Destinations.FirstOrDefaultAsync(x => x.DestinationId == id);
            if (destination == null)
            {
                return false;
            }
            _context.Destinations.Remove(destination);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}