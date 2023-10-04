using Microsoft.AspNetCore.Mvc;
using TripSupp.WebAPI.Data.Models;
using TripSupp.WebAPI.Services.Interfaces;

namespace TripSupp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationController : ControllerBase
    {
        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        [HttpGet()]
        public async ValueTask<IActionResult> Destination()
        {
            return Ok("Destination");
        }

        [HttpGet("GetAllDestinations")]
        public async ValueTask<IActionResult> GetAllDestinations()
        {
            ICollection<Destination> destinations = await _destinationService.GetAllDestinationsAsync();
            return Ok(destinations);
        }

        [HttpGet("GetDestinationById/{id}")]
        public async ValueTask<IActionResult> GetDestinationById(Guid id)
        {
            Destination destination = await _destinationService.GetDestinationByIdAsync(id);
            return Ok(destination);
        }

        [HttpPost("CreateDestination")]
        public async ValueTask<IActionResult> CreateDestination(Destination destination)
        {
            Destination createdDestination = await _destinationService.CreateDestinationAsync(destination);
            return Ok(createdDestination);
        }

        [HttpPut("UpdateDestination")]
        public async ValueTask<IActionResult> UpdateDestination(Destination destination)
        {
            Destination updatedDestination = await _destinationService.UpdateDestinationAsync(destination);
            return Ok(updatedDestination);
        }

        [HttpDelete("DeleteDestination/{id}")]
        public async ValueTask<IActionResult> DeleteDestination(Guid id)
        {
            bool isDeleted = await _destinationService.DeleteDestinationAsync(id);
            return Ok(isDeleted ? "Deleted successfully." : "Delete failed.");
        }
    }
}