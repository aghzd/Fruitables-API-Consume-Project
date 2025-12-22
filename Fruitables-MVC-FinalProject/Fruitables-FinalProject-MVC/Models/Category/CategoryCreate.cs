using System.ComponentModel.DataAnnotations;

namespace Fruitables_FinalProject_MVC.Models.Category
{
    public class CategoryCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}