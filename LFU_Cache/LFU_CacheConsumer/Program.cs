// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using src.Models;

var cache = new LFUCache<string, int>(10);
while (true)
{
    Console.WriteLine("""
    Welcome to the word lookup table:
        This program contains information about words
        and how frequently they appear. 
        The higher the number, the more frequent they are. 

        Type a word, and you'll get the frequency number, if we have it. 
    """);
    string word = "";
    while (string.IsNullOrWhiteSpace(word))
    {
        Console.WriteLine("Type a word:");
        word = Console.ReadLine()!;
    }
    var stopWatch = Stopwatch.StartNew();
    var cacheHit = cache.Get(word);

    if (cacheHit == 0)
    {
        var result = FileScanner<int>.Find("WordFrequencyList.txt", word);

        if (result == 0)
        {
            Console.WriteLine("We don't have information about that word, type another...");

            continue;
        }
        cacheHit = cache.Insert(word, result);
    }
    stopWatch.Stop();
    Console.WriteLine($"The frequency of {word}, is {cacheHit}. It took {stopWatch.ElapsedTicks} to find the result.");
}