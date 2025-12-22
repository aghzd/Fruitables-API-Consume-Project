using System.ComponentModel.DataAnnotations;

namespace Service.DTOs.StatsCard
{
    public class StatsCardEditDto
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