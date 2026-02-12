

using System.Net;
using AspNetCoreDemo.Extensions;
using AspNetCoreDemo.Models;
using AspNetCoreDemo.Models.Context;
using AspNetCoreDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDadJokeService(builder.Configuration);
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetService<DadJokeDbContext>();

    if (db is null) throw new InvalidOperationException(nameof(db));
    
    var service = scope.ServiceProvider.GetService<DadJokeService>();
    if (service is null) throw new InvalidOperationException(nameof(service));

    if (!await db.DadJokes.AnyAsync())
    {
        foreach(var joke in DadJokeSeedData.GenerateDadJokes())
        {
            await service.Add(joke);
        }
    }

}

app.Run();
