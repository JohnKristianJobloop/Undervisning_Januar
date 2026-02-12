using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreDemo.Models.Entities;

public class DadJokeEntity
{
    [Key]
    public int Id {get;init;}
    public required string Joke {get; init;}
}
