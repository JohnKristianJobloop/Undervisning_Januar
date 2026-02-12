using AspNetCoreDemo.Models;
using AspNetCoreDemo.Models.DTO;
using AspNetCoreDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
    public async Task<List<DadJokeResponseDTO>> GetAsync() => await service.GetAll();

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Post([FromBody] DadJokeRequestDTO joke) => await service.Add(joke) is DadJokeResponseDTO newJoke ? Created($"api/dadjokes/{newJoke.Id}", newJoke) : StatusCode(500, new { message= "Something went very wrong"});

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAsync(int id) => await service.Get(id) is DadJokeResponseDTO joke ? Ok(joke) : NotFound();
}
