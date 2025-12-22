using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class StatsCardConfiguration : IEntityTypeConfiguration<StatsCard>
    {
        public void Configure(EntityTypeBuilder<StatsCard> builder)
        {
            builder.Property(s => s.Name)
               .IsRequired()
               .HasMaxLength(120);

            builder.Property(s => s.Value)
                 .IsRequired();

            builder.Property(s => s.IconName)
                 .IsRequired()
                 .HasMaxLength (220);

            builder.Property(s => s.IsPercent)
                 .HasDefaultValue(false);
        }
    }
}