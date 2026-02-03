using System;
using System.Text.Json.Serialization;

namespace Http_Client_Exploration.Models;

public record DadJokeResponse(
    [property: JsonPropertyName("id")]string Id,
    [property: JsonPropertyName("joke")]string Joke,
    [property: JsonPropertyName("status")] int Status
    )
{
    public override string ToString() => Joke;
};
