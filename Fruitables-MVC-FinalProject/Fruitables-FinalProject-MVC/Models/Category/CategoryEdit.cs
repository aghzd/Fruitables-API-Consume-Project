using System.ComponentModel.DataAnnotations;

namespace Fruitables_FinalProject_MVC.Models.Category
{
    public class CategoryEdit
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}