using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Contact;
using Service.Services.Interfaces;

namespace App.Controllers.Client
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _service;
        public ContactController(IContactService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ContactCreateDto request)
        {
            await _service.CreateAsync(request);
            return CreatedAtAction(nameof(Create), "Created succesfully");
        }
    }
}