using System;
using src.Models;
using Xunit.Abstractions;

namespace Test.CacheReadSpeedTest;


public class CacheReadSpeedTests(ITestOutputHelper outputHelper)
{
    [Fact]
    public void AccessingSameWord_ShouldImproveFetchSpeed_FetchWordFromCache()
    {
        //Arrange
        string knownWord = "center";
        string fileName = "WordFrequencyList.txt";
        List<long>stopwatchResults = [];
        var cache = new LFUCache<string, int>(10);


        //Act
        for (int i = 0; i < 2; i++)
        {
            var stopWatch = System.Diagnostics.Stopwatch.StartNew();
            var cacheHit = cache.Get(knownWord);

            if (cacheHit == 0)
            {
                var result = FileScanner<int>.Find(AppContext.BaseDirectory, fileName, knownWord);

                if (result == 0)
                {
                    Console.WriteLine("We don't have information about that word, type another...");

                    continue;
                }
                cacheHit = cache.Insert(knownWord, result);
            }
            stopWatch.Stop();
            outputHelper.WriteLine(stopWatch.ElapsedTicks.ToString());
            stopwatchResults.Add(stopWatch.ElapsedTicks);
        }
        //Assert
        Assert.True(stopwatchResults[0] > stopwatchResults[1]);
    }
}
