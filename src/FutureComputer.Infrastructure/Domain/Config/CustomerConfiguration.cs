using FutureComputer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureComputer.Infrastructure.Domain.Config
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder) {

            builder.Property(a => a.Name)
                .IsRequired(false);

            builder.Property(a => a.Email)
                .IsRequired(true);

            builder.Property(a => a.Dob)
                .IsRequired(false);

            builder.Property(a => a.PhoneNumber)
                .IsRequired(false);

            builder.Property(a => a.Gender)
                .IsRequired(false);

            builder.Property(a => a.PhoneNumber)
                .IsRequired(false);

            builder.Property(a => a.IsAvailable)
                .HasDefaultValue(true);

            builder.Property(a => a.Addresses)
                .IsRequired(false);
        }
    }
}
