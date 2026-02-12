using System;
using AspNetCoreDemo.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreDemo.Models.Context;

public class DadJokeDbContext(DbContextOptions<DadJokeDbContext> options) : DbContext(options)
{
    public DbSet<DadJokeEntity> DadJokes => Set<DadJokeEntity>();
}
