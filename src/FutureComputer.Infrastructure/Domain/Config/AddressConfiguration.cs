using FutureComputer.Domain.Entities;
using FutureComputer.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FutureComputer.Infrastructure.Domain.Config;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.Property(a => a.AddressNumber)
                .IsRequired(false);

        builder.Property(a => a.AddressType)
                .HasDefaultValue(AddressType.Home);

        builder.Property(a => a.Street)
                .IsRequired(false);

        builder.Property(a => a.Province)
                .IsRequired(false);

        builder.Property(a => a.IsDefault)
                .HasDefaultValue(false);

        builder.Property(a => a.IsDeleted)
                .HasDefaultValue(false);
    }
}