using System.Reflection;
using CaseExtensions;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Caching.Memory;

namespace Smart.Design.Blazor;

public partial class SmartIcon : ComponentBase
{
    [Inject]
    public IMemoryCache? MemoryCache { get; set; }

    [Parameter]
    public Icon? Icon { get; set; }

    public MarkupString Svg { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        if (!Icon.HasValue)
        {
            return;
        }

        var iconName = $"{Icon.ToString().ToKebabCase()}.svg";
        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = assembly.GetManifestResourceNames().FirstOrDefault(resourceNames => resourceNames.EndsWith(iconName));
        if (resourceName is null)
            return;

        var svgFromEmbeddedResources = await new StreamReader(assembly.GetManifestResourceStream(resourceName)!).ReadToEndAsync();
        var svgFromCache = MemoryCache.Get<string>(iconName) ??
                                  MemoryCache.Set(iconName, svgFromEmbeddedResources, TimeSpan.FromHours(1));

        Svg = (MarkupString) svgFromCache;
    }
}