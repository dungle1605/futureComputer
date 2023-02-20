using FutureComputer.Domain.Entities;
using FutureComputer.Infrastructure.Domain.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FutureComputer.Infrastructure.Domain;

public class FutureComputerDbContext : DbContext
{
    private const int COMMAND_TIMEOUT_SECONDS = 1800;
    public FutureComputerDbContext(DbContextOptions<FutureComputerDbContext> options) : base(options)
    {
        try
        {
            Database.SetCommandTimeout(COMMAND_TIMEOUT_SECONDS);
        }
        catch { }
    }
    public DbSet<Address> Addresses { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<CompanyInfo> CompanyInfo { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //This will singularize all table names
        foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
        {
            entityType.SetTableName(entityType.DisplayName());
        }

        modelBuilder.ApplyConfiguration(new AddressConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new CompanyInfoConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
    }
}