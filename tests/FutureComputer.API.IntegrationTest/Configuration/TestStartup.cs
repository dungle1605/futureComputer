using Microsoft.Extensions.Configuration;

namespace FutureComputer.API.IntegrationTest.Configuration;

public class TestStartup : Startup
{
    public TestStartup(IConfiguration configuration) : base(configuration)
    {
    }
}