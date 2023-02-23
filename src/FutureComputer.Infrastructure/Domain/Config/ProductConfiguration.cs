using FutureComputer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FutureComputer.Infrastructure.Domain.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(a => a.Name)
                .IsRequired(true);

            builder.Property(a => a.ImageUrls)
                .IsRequired(true);

            builder.Property(p => p.Price)
                .IsRequired()
                .HasDefaultValue(1f);

            builder.Property(a => a.Quantity)
                .HasDefaultValue(1);

            builder.Property(a => a.Description)
                .IsRequired(false);

            builder.Property(a => a.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}
