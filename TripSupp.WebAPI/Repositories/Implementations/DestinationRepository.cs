using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TripSupp.WebAPI.Data;
using TripSupp.WebAPI.Data.Models;
using TripSupp.WebAPI.Dtos.RequestDtos;
using TripSupp.WebAPI.Repositories.Interfaces;

namespace TripSupp.WebAPI.Repositories.Implementations
{
    public class DestinationRepository : IDestinationRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public DestinationRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

        public async ValueTask<Destination> CreateDestinationAsync(DestinationRequest destinationRequest)
        {
            Destination destination = _mapper.Map<Destination>(destinationRequest);
            destination.DestinationId = Guid.NewGuid();
            bool isExisted = await _context.Destinations.AnyAsync(x => x.Title == destination.Title);
            if (isExisted)
            {
                throw new Exception("Destination with this title already exists");
            }
            await _context.Destinations.AddAsync(destination);
            await _context.SaveChangesAsync();
            return destination;
        }

        public async ValueTask<Destination> UpdateDestinationAsync(Guid destinationId, DestinationRequest destinationRequest)
        {

            Destination destination = await _context.Destinations.FirstOrDefaultAsync(x => x.DestinationId == destinationId);
            if (destination == null)
            {
                return null;
            }
            destination.Title = destinationRequest.Title;
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