using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace App.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    //[Authorize(Roles = "Admin,SuperAdmin")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _service;
        public ContactController(IContactService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contacts = await _service.GetAllAsync();
            return Ok(contacts);
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            try
            {
                var contact = await _service.GetByIdAsync(id);
                return Ok(contact);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}