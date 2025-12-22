using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class ProductOfferConfiguration : IEntityTypeConfiguration<ProductOffer>
    {
        public void Configure(EntityTypeBuilder<ProductOffer> builder)
        {
            builder.Property(s => s.Name)
                 .IsRequired()
                 .HasMaxLength(40);

            builder.Property(s => s.Description)
                .IsRequired();

            builder.Property(s => s.Image)
                 .IsRequired();

            builder.Property(s => s.BackgroundColor)
                 .IsRequired();

            builder.Property(s => s.NameColor)
                 .IsRequired();

            builder.Property(s => s.TextColor)
                 .IsRequired();
        }
    }
}