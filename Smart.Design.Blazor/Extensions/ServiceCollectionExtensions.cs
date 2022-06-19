using Microsoft.Extensions.DependencyInjection;

namespace Smart.Design.Blazor.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSmartDesign(this IServiceCollection services)
    {
        return services.AddMemoryCache();
    }
}
