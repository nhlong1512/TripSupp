using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripSupp.WebAPI.Data.Models;
using TripSupp.WebAPI.Dtos.RequestDtos;
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

        public async ValueTask<Destination> CreateDestinationAsync(DestinationRequest destinationRequest)
        {
            if (destinationRequest.Title == null || destinationRequest.Title == "")
            {
                throw new Exception("Title is required");
            }

            Destination createdDestination = await _destinationRepository.CreateDestinationAsync(destinationRequest);

            return createdDestination;
        }

        public async ValueTask<Destination> UpdateDestinationAsync(Guid destinationId, DestinationRequest destinationRequest)
        {
            Destination updatedDestination = await _destinationRepository.UpdateDestinationAsync(destinationId, destinationRequest);
            return updatedDestination;
        }

        public async ValueTask<bool> DeleteDestinationAsync(Guid id)
        {
            bool isDeleted = await _destinationRepository.DeleteDestinationAsync(id);
            return isDeleted;
        }

        public async ValueTask<bool> CheckDestinationExistedAsync(Guid id)
        {
            Destination destination = await _destinationRepository.GetDestinationByIdAsync(id);
            return destination != null;
        }
    }
}