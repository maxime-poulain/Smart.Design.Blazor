using System.Text.Json;

namespace BlazorApp1.Extensions;

public static class JsonExtensions
{
    public static string ToJson(this object source, JsonSerializerOptions? options = default) => JsonSerializer.Serialize(source, options);
}