using HimanshuPracticalBE.Models;
using HimanshuPracticalBE.Response;
using HimanshuPracticalBE.Respository;
using Microsoft.AspNetCore.Mvc;

namespace HimanshuPracticalBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;
        APIResponse response = new APIResponse();

        public LocationController(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        [HttpPost("AddLocation")]
        public async Task<IActionResult> AddLocation([FromBody] LocationModel model)
        {
            var result = await _locationRepository.AddLocation(model);

            if (result==null)
            {
                response.Success = false;
                response.ErrorMessage = "Oops!!! Something went wroung";
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            response.Success = true;
            response.Data = result;
            response.Message = "Location Added Successful";
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpGet("GetAllLocation")]
        public async Task<IActionResult> GetAllLocation()
        {
            var result = await _locationRepository.GetAllLocation();
            response.Data = result;

            if (result == null)
            {
                response.Success = false;
                response.ErrorMessage = "Oops!!! Something went wroung";
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            response.Success = true;
            response.Message = "Locations Getting Successful";
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpDelete("DeleteLocation/{Id}")]
        public async Task<IActionResult> DeleteLocation([FromRoute] int Id)
        {
            var result = await _locationRepository.DeleteLocation(Id);

            if (!result)
            {
                response.Success = false;
                response.ErrorMessage = "Oops!!! Something went wroung";
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            response.Success = true;
            response.Message = "Location Deleted Successful";
            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
