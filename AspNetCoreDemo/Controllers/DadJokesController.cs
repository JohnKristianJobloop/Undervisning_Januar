using System.Reflection.Metadata.Ecma335;
using AspNetCoreDemo.Models;
using AspNetCoreDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemo.Controllers;

[Route("api/[controller]")] //api/dadjokes + HTTPmetodenavn = god bedskrivelse av hvordan å bruke min resurs. 
/*
GET api/dadjokes = client wants to GET all jokes

POST api/dadjokes = POST new joke to dadjokes resource

GET api/dadjokes/{id} = client want to GET spesific JOKE with Id = id;
*/
[ApiController]
public class DadJokesController(DadJokeService service) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<List<DadJoke>> GetAsync() => [.. await Task.Run(()=>service.GetAll())];

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Post([FromBody] DadJoke joke) => Created($"api/DadJokes/{joke.Id}", await Task.Run(()=>service.Add(joke)));

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAsync(string id) => await Task.Run(()=>service.Get(id)) is DadJoke joke ? Ok(joke) : NotFound();
}
