using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripSupp.WebAPI.Data.Models;
using TripSupp.WebAPI.Dtos.RequestDtos;

namespace TripSupp.WebAPI.Repositories.Interfaces
{
    public interface IDestinationRepository
    {
        ValueTask<ICollection<Destination>> GetAllDestinationsAsync();
        ValueTask<Destination> GetDestinationByIdAsync(Guid id);
        ValueTask<Destination> CreateDestinationAsync(DestinationRequest destinationRequest);
        ValueTask<Destination> UpdateDestinationAsync(Guid destinationId, DestinationRequest destinationRequest);
        ValueTask<bool> DeleteDestinationAsync(Guid id);

    }
}