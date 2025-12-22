using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Account;
using Service.Services;
using Service.Services.Interfaces;

namespace App.Controllers.Client
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;
        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterDto request)
        {
            var result = await _service.RegisterAsync(request);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);  
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto request)
        {
            var result = await _service.LoginAsync(request);
            return Ok(result);
        }
    }
}