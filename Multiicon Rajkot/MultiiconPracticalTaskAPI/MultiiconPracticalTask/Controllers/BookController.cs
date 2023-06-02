using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiiconPracticalTask.Models;
using MultiiconPracticalTask.Repository;
using MultiiconPracticalTask.Response;

namespace MultiiconPracticalTask.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBaseRepository _baseRepository;
        APIResponse response = new APIResponse();

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpPost("AddBook")]
        public async Task<IActionResult> AddBook([FromBody] BookModel model)
        {
            var result = await _bookRepository.AddBook(model);

            if (!result)
            {
                response.Success = false;
                response.Message = "Oops!!! Something went wroung";
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            response.Success = true;
            response.Message = "Book Added Successful";
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPut("UpdateBook/{Id}")]
        public async Task<IActionResult> UpdateBook([FromRoute] int Id, [FromBody] BookModel model)
        {
            var result = await _bookRepository.UpdateBook(Id, model);

            if (!result)
            {
                response.Success = false;
                response.Message = "Oops!!! Something went wroung";
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            response.Success = true;
            response.Message = "Book Updated Successful";
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpGet("GetAllBook")]
        public async Task<IActionResult> GetAllBook()
        {
            var result = await _bookRepository.GetAllBook();
            response.Data = result;

            if (result == null)
            {
                response.Success = false;
                response.Message = "Oops!!! Something went wroung";
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            response.Success = true;
            response.Message = "Books Getting Successful";
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpGet("GetBookById/{Id}")]
        public async Task<IActionResult> GetBookById([FromRoute] int Id)
        {
            var result = await _bookRepository.GetBookById(Id);
            response.Data = result;

            if (result == null)
            {
                response.Success = false;
                response.Message = "Oops!!! Something went wroung";
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            response.Success = true;
            response.Message = "Book Getting Successful";
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpDelete("DeleteBook/{Id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int Id)
        {
            var result = await _bookRepository.DeleteBook(Id);

            if (!result)
            {
                response.Success = false;
                response.Message = "Oops!!! Something went wroung";
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            response.Success = true;
            response.Message = "Book Deleted Successful";
            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
