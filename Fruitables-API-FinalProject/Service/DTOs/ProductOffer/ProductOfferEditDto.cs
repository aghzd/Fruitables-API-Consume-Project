using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Service.DTOs.Service
{
    public class ProductOfferEditDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public IFormFile? Image { get; set; }
        [Required]
        public string BackgroundColor { get; set; }
        [Required]
        public string NameColor { get; set; }
        [Required]
        public string TextColor { get; set; }
    }
}