using HimanshuPracticalBE.Models;
using HimanshuPracticalBE.Response;
using HimanshuPracticalBE.Respository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HimanshuPracticalBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
        APIResponse response = new APIResponse();

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpPost("AddDepartment")]
        public async Task<IActionResult> AddDepartment([FromBody] DepartmentModel model)
        {
            var result = await _departmentRepository.AddDepartment(model);

            if (result==null)
            {
                response.Success = false;
                response.ErrorMessage = "Oops!!! Something went wroung";
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            response.Success = true;
            response.Data = result;
            response.Message = "Department Added Successful";
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpGet("GetAllDepartment")]
        public async Task<IActionResult> GetAllDepartment()
        {
            var result = await _departmentRepository.GetAllDepartment();
            response.Data = result;

            if (result == null)
            {
                response.Success = false;
                response.ErrorMessage = "Oops!!! Something went wroung";
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            response.Success = true;
            response.Message = "Departments Getting Successful";
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpDelete("DeleteDepartment/{Id}")]
        public async Task<IActionResult> DeleteDepartment([FromRoute] int Id)
        {
            var result = await _departmentRepository.DeleteDepartment(Id);

            if (!result)
            {
                response.Success = false;
                response.ErrorMessage = "Oops!!! Something went wroung";
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            response.Success = true;
            response.Message = "Department Deleted Successful";
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpGet("GetDepartmentWiseLocation/{userID}")]

        public async Task<IActionResult> GetDepartmentWiseLocation([FromRoute] int userID)
        {
            var result = await _departmentRepository.GetDepartmentWiseLocation(userID);
            response.Data = result;

            if (result == null)
            {
                response.Success = false;
                response.ErrorMessage = "Oops!!! Something went wroung";
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            response.Success = true;
            response.Message = "Departments Getting Successful";
            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
