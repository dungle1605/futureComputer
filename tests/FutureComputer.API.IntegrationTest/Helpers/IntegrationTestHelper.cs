using Newtonsoft.Json;
using System.Text;

namespace FutureComputer.API.IntegrationTest.Helpers;

public static class IntegrationTestHelper
{
    public static async Task<T> GetResponseContent<T>(HttpResponseMessage response)
    {
        var stringResponse = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<T>(stringResponse);

        return result;
    }

    public static StringContent ConvertBodyDataToString(object data)
    {
        var result = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

        return result;
    }
}