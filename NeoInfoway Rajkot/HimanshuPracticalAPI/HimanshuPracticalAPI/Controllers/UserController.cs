using HimanshuPracticalAPI.Models;
using HimanshuPracticalAPI.Repository;
using HimanshuPracticalAPI.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HimanshuPracticalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        APIResponse response = new APIResponse();

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] UserModel model)
        {
            var result = await _userRepository.AddUser(model);

            if (!result)
            {
                response.Success = false;
                response.ErrorMessage = "Oops!!! Something went wroung";
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            response.Success = true;
            response.Message = "User Added Successful";
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPut("UpdateUser/{Id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int Id, [FromBody] UserModel model)
        {
            var result = await _userRepository.UpdateUser(Id, model);

            if (!result)
            {
                response.Success = false;
                response.ErrorMessage = "Oops!!! Something went wroung";
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            response.Success = true;
            response.Message = "User Updated Successful";
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAllUser()
        {
            var result = await _userRepository.GetAllUser();
            response.Data = result;

            if (result == null)
            {
                response.Success = false;
                response.ErrorMessage = "Oops!!! Something went wroung";
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            response.Success = true;
            response.Message = "Users Getting Successful";
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpGet("GetCurrentLoggedInUser")]
        public async Task<IActionResult> GetCurrentLoggedInUser()
        {
            var result = await _userRepository.GetCurrentLoggedInUser();
            response.Data = result;

            if (result == null)
            {
                response.Success = false;
                response.ErrorMessage = "Oops!!! Something went wroung";
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            response.Success = true;
            response.Message = "User Getting Successful";
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpGet("GetUserById/{Id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int Id)
        {
            var result = await _userRepository.GetUserById(Id);
            response.Data = result;

            if (result == null)
            {
                response.Success = false;
                response.ErrorMessage = "Oops!!! Something went wroung";
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            response.Success = true;
            response.Message = "User Getting Successful";
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPost("CheckLogin")]
        public async Task<IActionResult> CheckUser([FromBody] LoginModel model)
        {
            var result = await _userRepository.CheckLogin(model);
            response.Data = result;

            if (result == null)
            {
                response.Success = false;
                response.ErrorMessage = "Oops!!! Something went wroung";
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            response.Success = true;
            response.Message = "User login Successful";
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpDelete("DeleteUser/{Id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int Id)
        {
            var result = await _userRepository.DeleteUser(Id);

            if (!result)
            {
                response.Success = false;
                response.ErrorMessage = "Oops!!! Something went wroung";
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            response.Success = true;
            response.Message = "User Deleted Successful";
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpGet("GetUserEducation")]
        public async Task<IActionResult> GetUserEducation([FromRoute] int Id)
        {
            var result = await _userRepository.GetUserEducation();

            if (result == null)
            {
                response.Success = false;
                response.ErrorMessage = "Oops!!! Something went wroung";
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            response.Success = true;
            response.Data = result;
            response.Message = "User Deleted Successful";
            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
