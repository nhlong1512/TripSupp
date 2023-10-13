using Microsoft.AspNetCore.Mvc;
using TripSupp.WebAPI.Models;
using TripSupp.WebAPI.Dtos.RequestDtos;
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
        public async ValueTask<IActionResult> CreateDestination(DestinationRequest destinationRequest)
        {
            Destination createdDestination = await _destinationService.CreateDestinationAsync(destinationRequest);
            return Ok(createdDestination);
        }

        [HttpPut("UpdateDestination")]
        public async ValueTask<IActionResult> UpdateDestination(Guid destinationId, DestinationRequest destinationRequest)
        {
            Destination updatedDestination = await _destinationService.UpdateDestinationAsync(destinationId, destinationRequest);
            return Ok(updatedDestination);
        }

        [HttpDelete("DeleteDestination/{id}")]
        public async ValueTask<IActionResult> DeleteDestination(Guid id)
        {
            bool isExisted = await _destinationService.CheckDestinationExistedAsync(id);
            if (!isExisted)
            {
                return NotFound("Destination not found.");
            }
            bool isDeleted = await _destinationService.DeleteDestinationAsync(id);
            return Ok(isDeleted ? "Deleted successfully." : "Delete failed.");
        }
    }
}