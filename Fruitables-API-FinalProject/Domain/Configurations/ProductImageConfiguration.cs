using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.Property(s => s.Name)
                .IsRequired();

            builder.Property(s => s.ProductId)
                 .IsRequired();

            builder.Property(s => s.IsMain)
                 .HasDefaultValue(false);
        }
    }
}