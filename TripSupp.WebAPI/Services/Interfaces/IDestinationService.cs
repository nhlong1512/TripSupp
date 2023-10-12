using TripSupp.WebAPI.Data.Models;
using TripSupp.WebAPI.Dtos.RequestDtos;

namespace TripSupp.WebAPI.Services.Interfaces
{
    public interface IDestinationService
    {
        ValueTask<ICollection<Destination>> GetAllDestinationsAsync();
        ValueTask<Destination> GetDestinationByIdAsync(Guid id);
        ValueTask<Destination> CreateDestinationAsync(DestinationRequest destination);
        ValueTask<Destination> UpdateDestinationAsync(Guid destinationId, DestinationRequest destinationRequest);
        ValueTask<bool> DeleteDestinationAsync(Guid id);
        ValueTask<bool> CheckDestinationExistedAsync(Guid id);
    }
}