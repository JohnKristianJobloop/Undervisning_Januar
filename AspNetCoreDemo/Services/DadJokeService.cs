using System;
using AspNetCoreDemo.Models;

namespace AspNetCoreDemo.Services;

public class DadJokeService(List<DadJoke> jokes)
{

    public IEnumerable<DadJoke> GetAll() => jokes;

    public DadJoke Add(DadJoke joke)
    {
        jokes.Add(joke); 
        return joke;
    }

    public DadJoke? Get(string id) => jokes.FirstOrDefault(joke => string.Equals(joke.Id, id));
}
