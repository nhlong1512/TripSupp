using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripSupp.WebAPI.Data.Models;

namespace TripSupp.WebAPI.Repositories.Interfaces
{
    public interface IDestinationRepository
    {
        ValueTask<ICollection<Destination>> GetAllDestinationsAsync();
        ValueTask<Destination> GetDestinationByIdAsync(Guid id);
        ValueTask<Destination> CreateDestinationAsync(Destination destination);
        ValueTask<Destination> UpdateDestinationAsync(Destination destination);
        ValueTask<bool> DeleteDestinationAsync(Guid id);

    }
}