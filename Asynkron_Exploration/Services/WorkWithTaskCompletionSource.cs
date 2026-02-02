using System;
using Asynkron_Exploration.Models;

namespace Asynkron_Exploration.Services;

public class WorkWithTaskCompletionSource
{

    public static Task CountTwoCountersUsingTask()
    {
        var work1 = new Work(10, "Worker 3", 50);
        var work2 = new Work(5, "Worker4", 120);

        var task1 = SetUpTscForSingleWork(work1);
        var task2 = SetUpTscForSingleWork(work2);

        var masterTsc = new TaskCompletionSource();

        Task.WhenAll(task1, task2).ContinueWith(allTasks =>
        {
            foreach (var name in allTasks.Result) Console.WriteLine($"{name} is marked complete in master tsc");
            masterTsc.SetResult();
        });
        return masterTsc.Task;
    }
    private static Task<string> SetUpTscForSingleWork(Work work)
    {
        var tsc = new TaskCompletionSource<string>();

        Task.Run(() =>
        {
            Console.WriteLine($"{work.Name} starts..");
            WorkWithTaskAwaiter(work, tsc);
        });
        return tsc.Task;
    }
    private static void WorkWithTaskAwaiter(Work work, TaskCompletionSource<string> tsc)
    {
        int current = 0;

        void Continuation()
        {
            if (current < work.Count)
            {
                var delayTask = Task.Delay(work.DelayInMs);
                Console.WriteLine($"{work.Name} has completed {++current} amount of work....");

                var awaiter = delayTask.GetAwaiter();

                awaiter.OnCompleted(() =>
                {
                    Continuation();
                });
            }
            else
            {
                Console.WriteLine($"{work.Name} has completed..");
                tsc.SetResult(work.Name);
            }
        }
        Continuation();
    }
}
