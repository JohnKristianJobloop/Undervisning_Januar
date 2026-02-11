using System;
using AspNetCoreDemo.Models;
using AspNetCoreDemo.Services;

namespace AspNetCoreDemo.Extensions;

public static class DadJokeServiceCollectionExtension
{
    extension(IServiceCollection collection)
    {
        public IServiceCollection AddDadJokeService()
        {
            collection.AddSingleton<List<DadJoke>>(_ => DadJokeSeedData.GenerateDadJokes().ToList());
            collection.AddTransient<DadJokeService>();
            return collection;
        }
    }

}
