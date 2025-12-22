using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(70);

            builder.Property(s => s.Description)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(s => s.Price)
                .IsRequired();

            builder.Property(s => s.Unit)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(s => s.CategoryId)
                .IsRequired();
        }
    }
}