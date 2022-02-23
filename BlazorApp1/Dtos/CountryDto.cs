using System.Text.Json.Serialization;

namespace BlazorApp1.Dtos;

public class Country
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("code")]
    public string? Code { get; set; }
}