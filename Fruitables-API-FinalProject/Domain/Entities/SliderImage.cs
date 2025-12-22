namespace Domain.Entities
{
    public class SliderImage:BaseEntity
    {
        public string CategoryName { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
    }
}