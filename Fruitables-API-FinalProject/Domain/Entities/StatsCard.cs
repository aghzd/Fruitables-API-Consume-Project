namespace Domain.Entities
{
    public class StatsCard : BaseEntity
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public string IconName { get; set; }
        public bool IsPercent { get; set; }
    }
}