using System.Text.Json;

namespace Smart.Design.Blazor.WebSample.Extensions
{
    public static class JsonExtensions
    {
        public static string ToJson(this object source, JsonSerializerOptions options = default) => JsonSerializer.Serialize(source, options);
    }
}
