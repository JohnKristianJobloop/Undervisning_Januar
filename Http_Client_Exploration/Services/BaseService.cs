using System;

namespace Http_Client_Exploration.Services;

public class BaseService
{
    public async Task FetchFromEndpoint(string endpoint, HttpClient client)
    {
        try
        {
            var response = await client.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Received {content} from {endpoint}...");
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Something went wrong in request from {endpoint}: {e.Message}");
        }
    }
}
