using ApiTest.Attributes;
using ApiTest.Attributes.Enums;
using ApiTest.Models.Dtos;
using ApiTest.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        AuthService _authService;
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [ApiTestAttribute(AttributeTypes.LOGIN)]
        public async Task<IActionResult> Login([FromBody]LoginDto loginDto)
        {
            try
            {
                return Ok(_authService.Login(loginDto.Name, loginDto.Password, HttpContext));
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
