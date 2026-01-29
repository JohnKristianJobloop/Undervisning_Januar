using Solid_Exploration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi





builder.Services.AddOpenApi();

builder.Services.AddTransient<DependencyInversionPrinciple>();




builder.Services.AddScoped<DataHandler>();




builder.Services.AddKeyedSingleton<IDatabase, SQLDatabase>("SQL");

builder.Services.AddKeyedSingleton<IDatabase, ExcelDatabase>("Excel");

builder.Services.AddKeyedSingleton<IDatabase, SupabaseDatabase>("Supabase");




















var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", (DataHandler principle) =>
{
    //DataHandler starter å eksistere når dette scopet blir kallet (ca her?)
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
    //DataHandler blir disposed / garbagecollected her, siden scopet er ferdig.
})
.WithName("GetWeatherForecast");


app.MapGet("fetchData", ([FromKeyedServices("SQL")] IDatabase database) =>
{
    database.SaveOrder(new Order(1, "to@hello.com"));
});

app.MapGet("excelOrder", ([FromKeyedServices("Excel")] IDatabase database) => {});

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
