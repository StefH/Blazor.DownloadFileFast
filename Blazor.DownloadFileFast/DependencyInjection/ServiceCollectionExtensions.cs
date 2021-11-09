using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.JSInterop;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the Blazor Download file Service
    /// </summary>
    public static IServiceCollection AddBlazorDownloadFile(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Scoped)
    {
        return ServiceCollectionDescriptorExtensions.Add(services,
            new ServiceDescriptor(typeof(IBlazorDownloadFileService),
            sp => new BlazorDownloadFileService(sp.GetRequiredService<IJSRuntime>()),
            lifetime));
    }
}