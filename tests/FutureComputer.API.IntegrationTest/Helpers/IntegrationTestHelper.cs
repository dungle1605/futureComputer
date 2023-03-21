using Newtonsoft.Json;

namespace FutureComputer.API.IntegrationTest.Helpers;

public static class IntegrationTestHelper
{
    public static async Task<T> GetResponseContent<T>(HttpResponseMessage response)
    {
        var stringResponse = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<T>(stringResponse);

        return result;
    }
}