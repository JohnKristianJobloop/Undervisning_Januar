using System;
using AspNetCoreDemo.Models.Context;
using AspNetCoreDemo.Models.DTO;
using AspNetCoreDemo.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreDemo.Services;

public class DadJokeService(DadJokeDbContext jokesDb)
{
    public async Task<List<DadJokeResponseDTO>> GetAll() => await jokesDb.DadJokes.Select(joke => new DadJokeResponseDTO(joke.Id, joke.Joke)).ToListAsync();

    public async Task<DadJokeResponseDTO> Add(DadJokeRequestDTO joke)
    {
        var newJoke = new DadJokeEntity{Joke = joke.DadJoke};
        await jokesDb.DadJokes.AddAsync(newJoke);
        await jokesDb.SaveChangesAsync();
        return new DadJokeResponseDTO(newJoke.Id, newJoke.Joke);
    }

    public async Task<DadJokeResponseDTO?> Get(int id) => await jokesDb.DadJokes
                                                                        .Where(joke => joke.Id == id)
                                                                        .Select(joke => new DadJokeResponseDTO(joke.Id, joke.Joke))
                                                                        .FirstOrDefaultAsync();
}
