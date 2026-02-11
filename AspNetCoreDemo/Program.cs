

using AspNetCoreDemo.Extensions;
using AspNetCoreDemo.Models;
using AspNetCoreDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDadJokeService();
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

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.MapGet("/hello", () =>
{
    return "Hello!";
});

app.MapGet("/add/{num1:int}/{num2:int}", (int num1, int num2) =>
{
    return num1 + num2;
});

app.MapGet("/ask", ([FromQuery] string question) =>
{
    return $"{question} I don't have the answer...";
});


app.MapPost("/user", ([FromBody] User user) =>
{
    return $"new user: {user.Name} recieved";
});

app.MapGet("/jokes", (IEnumerable<DadJoke> jokes)=> jokes);

app.MapPost("/jokes", ([FromBody] DadJoke joke, IEnumerable<DadJoke> jokes) =>
{
    jokes = jokes.Append(joke);
    return Results.Created($"/jokes/{joke.Id}", joke);
});

app.MapGet("/jokes/{id}", (string id, IEnumerable<DadJoke> jokes)=> jokes.FirstOrDefault(joke => string.Equals(id, joke.Id)));

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

record User(string Name, int Age);