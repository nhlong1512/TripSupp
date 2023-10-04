using TripSupp.WebAPI.Data.Models;

namespace TripSupp.WebAPI.Services.Interfaces
{
    public interface IDestinationService
    {
        ValueTask<ICollection<Destination>> GetAllDestinationsAsync();
        ValueTask<Destination> GetDestinationByIdAsync(Guid id);
        ValueTask<Destination> CreateDestinationAsync(Destination destination);
        ValueTask<Destination> UpdateDestinationAsync(Destination destination);
        ValueTask<bool> DeleteDestinationAsync(Guid id);
    }
}