using FutureComputer.Infrastructure.Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FutureComputer.API.IntegrationTest.Configuration;

public class TestingWebAppFactory<TEntryPoint> : WebApplicationFactory<Program> where TEntryPoint : Program
{
    private readonly string _dbName = Guid.NewGuid().ToString();
    public FutureComputerDbContext FCDbContext;
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<FutureComputerDbContext>));

            if (descriptor != null)
                services.Remove(descriptor);

            services.AddDbContext<FutureComputerDbContext>(opts =>
            {
                opts.UseInMemoryDatabase(_dbName);
            });

            var sp = services.BuildServiceProvider();
            var scope = sp.CreateScope();
            FCDbContext = scope.ServiceProvider.GetRequiredService<FutureComputerDbContext>();

            try
            {
                FCDbContext.Database.EnsureDeleted();
                FCDbContext.Database.EnsureCreated();
            }
            catch (Exception)
            {
                throw;
            }
        });
    }
}