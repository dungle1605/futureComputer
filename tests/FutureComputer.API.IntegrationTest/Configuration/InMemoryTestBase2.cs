using FutureComputer.Infrastructure.Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FutureComputer.API.IntegrationTest.Configuration;

public class InMemoryTestBase2
{
    protected FutureComputerDbContext _fcDbContext;

    private static IConfiguration _configuration { get; } = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.test.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables()
        .Build();

    private IServiceProvider _serviceProvider { get; set; }

    protected async Task<HttpClient> CreateClient()
    {
        var hostBuilder = new HostBuilder()
            .ConfigureWebHost(webHost =>
            {
                webHost.UseTestServer()
                    .UseConfiguration(_configuration)
                    .UseStartup<TestStartup>();
            })
            .ConfigureServices(services => ConfigureServices(services));

        // Create and start up the host
        var host = await hostBuilder.StartAsync();

        // Create a HttpClient which is setup for the test host
        var client = host.GetTestClient();

        // Increase HttpClient timeout and reduce the threads of test runner
        client.Timeout = TimeSpan.FromMinutes(5);
        return client;
    }

    private void ConfigureServices(IServiceCollection services)
    {
        ConfigureDb(services);

        _serviceProvider = services.BuildServiceProvider();
    }

    private void ConfigureDb(IServiceCollection services)
    {
        string inMemoryConnectionString = _configuration.GetConnectionString("FutureComputerTest");
        // string inMemoryConnectionString = Guid.NewGuid().ToString();
        // EFCore replace SQLServer by SQlite
        var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<FutureComputerDbContext>));
        services.Remove(descriptor);
        services.AddDbContext<FutureComputerDbContext>(opts =>
        {
            opts.UseInMemoryDatabase(inMemoryConnectionString);
        });

        var sp = services.BuildServiceProvider();
        _fcDbContext = sp.GetRequiredService<FutureComputerDbContext>();
        // Re-create DB for every test
        _fcDbContext.Database.EnsureDeleted();
        _fcDbContext.Database.EnsureCreated();
    }

    public T Resolve<T>() where T : class
    {
        return (T)Resolve(typeof(T));
    }

    public object Resolve(Type type)
    {
        if (_serviceProvider == null)
            return null;
        return _serviceProvider.GetRequiredService(type);
    }
}