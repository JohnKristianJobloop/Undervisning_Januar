using System.Diagnostics;
using Asynkron_Exploration.Services;
/*
var newThread = new Thread(Process);
var stopWatch = Stopwatch.StartNew();

newThread.Start();

newThread.Join();

stopWatch.Stop();

Console.WriteLine($"Subthread took: {stopWatch.ElapsedMilliseconds} ms to complete"); */

var threadStopWatch = Stopwatch.StartNew();
WorkWithThreads.CreateAndRunTwoThreadsDoingWork();
threadStopWatch.Stop();


var taskStopWatch = Stopwatch.StartNew();
var awaiter = WorkWithTaskCompletionSource.CountTwoCountersUsingTask();
awaiter.Wait();
taskStopWatch.Stop();


var asyncStopWatch = Stopwatch.StartNew();
await WorkWithAsyncAwait.WorkOnAsyncAwaitTwoWorkObjects();
asyncStopWatch.Stop();


Console.WriteLine("Processing Complete...");

Console.WriteLine($"Thread work took {threadStopWatch.ElapsedMilliseconds}ms to complete");
Console.WriteLine($"Task work took {taskStopWatch.ElapsedMilliseconds}ms to complete");
Console.WriteLine($"Async/Await work took {asyncStopWatch.ElapsedMilliseconds}ms to complete");


static void Process()
{
    for (int i = 0; i < 50; i++)
    {
        Console.WriteLine($"Processing...step: {i}");
    }
}