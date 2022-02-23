using System.Threading.Tasks;
using System.Web;
using Microsoft.JSInterop;

namespace BlazorApp1.Extensions;

public static class JsExtensions
{
    public static ValueTask ConsoleLogAsync(this IJSRuntime js, string? message) 
        => js.InvokeVoidAsync("console.log",HttpUtility.JavaScriptStringEncode(message));
}