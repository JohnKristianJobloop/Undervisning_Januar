using System;
using Asynkron_Exploration.Models;

namespace Asynkron_Exploration.Services;

public static class WorkWithAsyncAwait
{

    public static async Task WorkOnAsyncAwaitTwoWorkObjects()
    {
        var work1 = new Work(10, "Worker 1", 50);
        var work2 = new Work(5, "Worker 2", 120);

        var task1 = WorkOnTaskAsync(work1);
        var task2 = WorkOnTaskAsync(work2);

        var names = await Task.WhenAll(task1, task2);
        foreach(var name in names)Console.WriteLine($"{name} is complete");
    }

    private static async Task<string> WorkOnTaskAsync(Work work)
    {
        Console.WriteLine($"{work.Name} starts...");

        for (int i = 0; i < work.Count; i++)
        {
            await Task.Delay(work.DelayInMs);
            Console.WriteLine($"{work.Name} has completed {i + 1} amount of work");
        }
        Console.WriteLine($"{work.Name} is complete");
        return work.Name;
    }

}
