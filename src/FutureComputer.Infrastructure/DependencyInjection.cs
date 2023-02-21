using FutureComputer.Domain.Interfaces;
using FutureComputer.Infrastructure.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FutureComputer.Infrastructure;

public static class DependencyInjection
{
    public static void AddServicesInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
        services.AddScoped(typeof(IReadRepository<>), typeof(EFRepository<>));
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<FutureComputerDbContext>(opts => opts.UseSqlServer(configuration.GetConnectionString("FutureComputer")));
    }
}
