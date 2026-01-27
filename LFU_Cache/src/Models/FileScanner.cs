using System;

namespace src.Models;

public static class FileScanner<T> where T : IParsable<T>
{
    public static T? Find(string fileName, string word)

    {
        var path = Path.Combine("/home/johnkristianellingsen/Dokumenter/forelesning/Undervisning_Januar/LFU_Cache/LFU_CacheConsumer/", fileName);
        if (!File.Exists(path)) return default;

        foreach (var line in File.ReadLines(path))
        {
            var data = line.Split(',');
            if (string.Equals(word, data[0], StringComparison.OrdinalIgnoreCase) && T.TryParse(data[1], null, out T? result))
            {
                return result;
            }
        }
        return default;
    }
}
