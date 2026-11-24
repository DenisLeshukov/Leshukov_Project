using ExchangeApp.API.Models.Entities;
using ExchangeApp.API.Services;
using ExchangeApp.Shared.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApp.API.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    public class Auth : ControllerBase
    {
        private readonly AuthService _service;
        public Auth(AuthService service) { 
            _service = service;
        }

        [HttpPost("register")]
        public IActionResult Register(UserDTO user)
        {
            _service.RegisterUser(user);
            return Ok();
        }
    }
}
