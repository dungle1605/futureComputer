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
    public class CompanyInfoConfiguration : IEntityTypeConfiguration<CompanyInfo>
    {
        public void Configure(EntityTypeBuilder<CompanyInfo> builder)
        {
            builder.Property(a => a.CompanyName)
                .IsRequired(true);

            builder.Property(a => a.CompanyCode)
                .IsRequired(true);

            builder.Property(a => a.AddressDetail)
                .IsRequired(true);

            builder.Property(a => a.PhoneNumber)
                .IsRequired(true);

            builder.Property(a => a.IsAvailable)
                .HasDefaultValue(true);
        }
    }
}
