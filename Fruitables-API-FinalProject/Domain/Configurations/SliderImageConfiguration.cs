using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class SliderImageConfiguration : IEntityTypeConfiguration<SliderImage>
    {
        public void Configure(EntityTypeBuilder<SliderImage> builder)
        {
            builder.Property(s => s.CategoryName)
                 .IsRequired();

            builder.Property(s => s.Image)
                 .IsRequired();

            builder.Property(s => s.IsActive)
                 .HasDefaultValue(false);
        }
    }
}