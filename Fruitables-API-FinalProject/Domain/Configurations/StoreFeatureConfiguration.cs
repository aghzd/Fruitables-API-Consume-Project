using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class StoreFeatureConfiguration : IEntityTypeConfiguration<StoreFeature>
    {
        public void Configure(EntityTypeBuilder<StoreFeature> builder)
        {
            builder.Property(f => f.IconName)
                .IsRequired()
                .HasMaxLength(140);

            builder.Property(f => f.Feature)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(f => f.Feature)
                .IsRequired()
                .HasMaxLength(300);
        }
    }
}
