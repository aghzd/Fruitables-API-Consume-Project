using System.ComponentModel.DataAnnotations;

namespace Fruitables_FinalProject_MVC.Models.StatsCard
{
    public class StatsCardCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Value { get; set; }
        [Required]
        public string IconName { get; set; }
        [Required]
        public bool IsPercent { get; set; }
    }
}