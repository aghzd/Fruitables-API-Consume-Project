using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(70);

            builder.Property(s => s.Email)
               .IsRequired()
               .HasMaxLength(70);

            builder.Property(s => s.Message)
               .IsRequired();
        }
    }
}