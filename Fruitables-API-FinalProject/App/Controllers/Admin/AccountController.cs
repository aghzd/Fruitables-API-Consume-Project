using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Account;
using Service.Services.Interfaces;

namespace App.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;
        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _service.GetUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] string id)
        {
            var user = await _service.GetUserById(id);  
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoles()
        {
            await _service.CreateRolesAsync();
            return Ok();
        }

        [HttpGet]
        //[Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _service.GetRolesAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById([FromRoute] string id)
        {
            var role = await _service.GetRoleByIdAsync(id);
            return Ok(role);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser([FromQuery] string id)
        {
            await _service.DeleteUserAsync(id);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveRoleToUser([FromBody] UserRoleDto request)
        {
            var result = await _service.RemoveRoleFromUser(request);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddRoleToUser([FromBody] UserRoleDto request)
        {
            var response = await _service.AddRoleToUserAsync(request);
            if (!response.IsSuccess)
                return BadRequest(response);

            return CreatedAtAction(nameof(AddRoleToUser),response);
        }

       
    }
}