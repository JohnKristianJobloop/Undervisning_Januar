// See https://aka.ms/new-console-template for more information
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Http_Client_Exploration.Models;
using Http_Client_Exploration.Services;

Console.WriteLine("Hello, World!");

var client = new HttpClient();

/*var response = await client.GetAsync("https://nrk.no");
Console.WriteLine(response.StatusCode);

var content = response.Content;

var fileName = "response.html";

await File.AppendAllTextAsync(Path.Combine(AppContext.BaseDirectory, fileName), await content.ReadAsStringAsync());

Console.WriteLine("Done!");*/

/*client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

var response = await client.GetAsync("https://icanhazdadjoke.com");

var joke = await response.Content.ReadFromJsonAsync<DadJokeResponse>();

Console.WriteLine(joke.ToString());*/

client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

List<string> endpoints = [
    "https://icanhazdadjoke.com",
    "https://official-joke-api.appspot.com/random_joke",
    "https://api.chucknorris.io/jokes/random"
];

var parallellService = new ParallellBaseService();
var sequentialSerice = new SequentialBaseService();

await sequentialSerice.SendGetRequestsSequentialWithStopWatch(endpoints, client);

await parallellService.ParallellGetRequestsToEndpointsWithStopWatch(endpoints, client);