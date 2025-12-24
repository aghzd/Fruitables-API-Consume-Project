using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Service;
using Service.DTOs.SliderImage;
using Service.Helpers.Exceptions;
using Service.Services;
using Service.Services.Interfaces;

namespace App.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class ProductOfferController : ControllerBase
    {
        private readonly IProductOfferService _service;
        public ProductOfferController(IProductOfferService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductOfferCreateDto request)
        {
            await _service.CreateAsync(request);
            return CreatedAtAction(nameof(Create), "Created Succesfully");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "SuperAdmin")]
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productOffers = await _service.GetAllAsync();
            return Ok(productOffers);
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
           
            try
            {
                var productOffer = await _service.GetByIdAsync(id);
                return Ok(productOffer);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromForm] ProductOfferEditDto request)
        {
           
            try
            {
                await _service.EditAsync(id, request);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}