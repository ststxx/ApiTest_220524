using ApiTest.Exceptions;
using ApiTest.Models.Dtos;
using ApiTest.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controllers
{
    [Authorize]
    [Route("users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                return Ok(_userRepository.FindAll());
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(string id)
        {
            try
            {
                return Ok(_userRepository.FindById(id));
            }
            catch (Exception e)
            {
                return ExceptionHandler(e);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateDto userCreateDto)
        {
            try
            {
                return Ok(_userRepository.Create(userCreateDto));
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private IActionResult ExceptionHandler(Exception e)
        {
            HttpContext.Response.ContentType = "application/json";
            if (e is UnknownException)
                return BadRequest((e as UnknownException).ToErrorResponse());
            if (e is IdNotExistException)
                return BadRequest((e as IdNotExistException).ToErrorResponse());
            if (e is IdLengthException)
                return BadRequest((e as IdLengthException).ToErrorResponse());
            return BadRequest(e.ToString());
        }
    }
}
