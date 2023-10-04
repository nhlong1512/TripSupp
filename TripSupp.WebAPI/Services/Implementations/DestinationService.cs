using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripSupp.WebAPI.Data.Models;
using TripSupp.WebAPI.Repositories.Interfaces;
using TripSupp.WebAPI.Services.Interfaces;

namespace TripSupp.WebAPI.Services.Implementations
{
    public class DestinationService : IDestinationService
    {
        private readonly IDestinationRepository _destinationRepository;
        public DestinationService(IDestinationRepository destinationRepository)
        {
            _destinationRepository = destinationRepository;
        }

        public async ValueTask<ICollection<Destination>> GetAllDestinationsAsync()
        {
            ICollection<Destination> destinations = await _destinationRepository.GetAllDestinationsAsync();
            return destinations;
        }

        public async ValueTask<Destination> GetDestinationByIdAsync(Guid id)
        {
            Destination destination = await _destinationRepository.GetDestinationByIdAsync(id);
            return destination;
        }

        public async ValueTask<Destination> CreateDestinationAsync(Destination destination)
        {
            Destination createdDestination = await _destinationRepository.CreateDestinationAsync(destination);
            return createdDestination;
        }

        public async ValueTask<Destination> UpdateDestinationAsync(Destination destination)
        {
            Destination updatedDestination = await _destinationRepository.UpdateDestinationAsync(destination);
            return updatedDestination;
        }

        public async ValueTask<bool> DeleteDestinationAsync(Guid id)
        {
            bool isDeleted = await _destinationRepository.DeleteDestinationAsync(id);
            return isDeleted;
        }
    }
}