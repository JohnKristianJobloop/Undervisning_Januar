using System;
using System.Diagnostics;

namespace Http_Client_Exploration.Services;

public class SequentialBaseService : BaseService
{
    public async Task SendGetRequestsSequentialWithStopWatch(IEnumerable<string> endpoints, HttpClient client)
    {
        var stopwatch = Stopwatch.StartNew();
        foreach (var endpoint in endpoints)
        {
            await FetchFromEndpoint(endpoint, client);
        }
        stopwatch.Stop();
        Console.WriteLine($"Sequential Operation took: {stopwatch.ElapsedMilliseconds}ms to complete...");
    }

}
