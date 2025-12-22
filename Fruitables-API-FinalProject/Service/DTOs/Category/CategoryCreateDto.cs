using System.ComponentModel.DataAnnotations;

namespace Service.DTOs.Category
{
    public class CategoryCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}