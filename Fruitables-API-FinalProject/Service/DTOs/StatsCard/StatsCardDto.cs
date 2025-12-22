namespace Service.DTOs.StatsCard
{
    public class StatsCardDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public string IconName { get; set; }
        public bool IsPercent { get; set; }
    }
}