using FutureComputer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FutureComputer.Infrastructure.Domain.Config
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {

            builder.Property(a => a.Name)
                .IsRequired(true);

            builder.Property(a => a.Email)
                .IsRequired(true);

            builder.Property(a => a.Dob)
                .IsRequired(true);

            builder.Property(a => a.PhoneNumber)
                .IsRequired(false);

            builder.Property(a => a.Gender)
                .IsRequired(false);

            builder.Property(a => a.PhoneNumber)
                .IsRequired(false);

            builder.Property(a => a.IsAvailable)
                .HasDefaultValue(true);
        }
    }
}
