using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(70);

            builder.Property(s => s.IsActive)
                 .HasDefaultValue(false);
        }
    }
}