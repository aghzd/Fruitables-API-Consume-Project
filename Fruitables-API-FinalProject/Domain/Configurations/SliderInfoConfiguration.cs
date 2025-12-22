using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class SliderInfoConfiguration : IEntityTypeConfiguration<SliderInfo>
    {
        public void Configure(EntityTypeBuilder<SliderInfo> builder)
        {
            builder.Property(s => s.Title)
                .IsRequired()
                .HasMaxLength(70);

            builder.Property(s => s.Description)
                .IsRequired()
                .HasMaxLength(70);

            builder.Property(s => s.BackgroundImage)
                .IsRequired();
        }
    }
}