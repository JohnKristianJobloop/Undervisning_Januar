using System;
using Asynkron_Exploration.Models;

namespace Asynkron_Exploration.Services;

public static class WorkWithThreads
{
    public static void CreateAndRunTwoThreadsDoingWork()
    {
        var work1 = new Work(10, "Worker 1", 50);
        var work2 = new Work(5, "Worker 2", 120);

        var thread1 = new Thread(()=>WorkOnThread(work1));
        var thread2 = new Thread(()=>WorkOnThread(work2));
        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();

        Console.WriteLine("Both threads have completed their work.");
    }

    private static void WorkOnThread(Work work)
    {
        Console.WriteLine($"Thread {work.Name} starts...");

        for (int i= 0; i < work.Count; i++)
        {
            Thread.Sleep(work.DelayInMs);
            Console.WriteLine($"{work.Name} has completed {i+1} amount of work...");
        }
        Console.WriteLine($"{work.Name} complete..");
    }
}
