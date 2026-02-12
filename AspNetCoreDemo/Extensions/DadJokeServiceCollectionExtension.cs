using System;
using AspNetCoreDemo.Models;
using AspNetCoreDemo.Models.Context;
using AspNetCoreDemo.Models.DTO;
using AspNetCoreDemo.Services;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreDemo.Extensions;

public static class DadJokeServiceCollectionExtension
{
    extension(IServiceCollection collection)
    {
        public IServiceCollection AddDadJokeService(IConfiguration configuration)
        {
            collection.AddDbContext<DadJokeDbContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            });
            collection.AddTransient<DadJokeService>();
            return collection;
        }
    }

}
