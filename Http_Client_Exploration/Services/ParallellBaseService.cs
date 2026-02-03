using System;
using System.Diagnostics;

namespace Http_Client_Exploration.Services;

public class ParallellBaseService : BaseService
{
    public async Task ParallellGetRequestsToEndpointsWithStopWatch(IEnumerable<string>endpoints, HttpClient client)
    {
        var stopwatch = Stopwatch.StartNew();

        List<Task> tasks = [..endpoints.Select(endpoint => FetchFromEndpoint(endpoint, client))]; //[.. linq] er det samme som å skrive linq.ToList();

        await Task.WhenAll(tasks);

        stopwatch.Stop();

        Console.WriteLine($"Parallell execution took {stopwatch.ElapsedMilliseconds}ms to complete...");
    }
}
