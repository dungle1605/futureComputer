using FutureComputer.Infrastructure.Domain;

namespace FutureComputer.API.IntegrationTest.Configuration;

public class InMemoryTestBase : IClassFixture<TestingWebAppFactory<Program>>
{
    protected readonly HttpClient _client;
    protected FutureComputerDbContext _fcDbContext;

    public InMemoryTestBase(TestingWebAppFactory<Program> factory)
    {
        _client = factory.CreateClient();
        _fcDbContext = factory.FCDbContext;
    }
}