using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiiconPracticalTask.Models;
using MultiiconPracticalTask.Repository;
using MultiiconPracticalTask.Response;

namespace MultiiconPracticalTask.Controllers
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
                response.Message = "Oops!!! Something went wroung";
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            response.Success = true;
            response.Message = "User Added Successful";
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UserModel model)
        {
            var result = await _userRepository.UpdateUser(model);

            if (!result)
            {
                response.Success = false;
                response.Message = "Oops!!! Something went wroung";
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
                response.Message = "Oops!!! Something went wroung";
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            response.Success = true;
            response.Message = "Users Getting Successful";
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUserById()
        {
            var result = await _userRepository.GetUserById();
            response.Data = result;

            if (result == null)
            {
                response.Success = false;
                response.Message = "Oops!!! Something went wroung";
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            response.Success = true;
            response.Message = "User Getting Successful";
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPost("CheckUser")]
        public async Task<IActionResult> CheckUser([FromBody] LoginModel model)
        {
            var result = await _userRepository.CheckLogin(model);
            response.Data = result;

            if (result == null)
            {
                response.Success = false;
                response.Message = "Oops!!! Something went wroung";
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            response.Success = true;
            response.Message = "User login Successful";
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser()
        {
            var result = await _userRepository.DeleteUser();

            if (!result)
            {
                response.Success = false;
                response.Message = "Oops!!! Something went wroung";
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            response.Success = true;
            response.Message = "User Deleted Successful";
            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
