using Blazor.DownloadFile.Interfaces;
using Blazor.DownloadFile.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.JSInterop;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers blazor download file service
        /// </summary>
        public static IServiceCollection AddBlazorDownloadFile(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            return ServiceCollectionDescriptorExtensions.Add(services,
                new ServiceDescriptor(typeof(IBlazorDownloadFileService),
                sp => new BlazorDownloadFileService(sp.GetRequiredService<IJSRuntime>()),
                lifetime));
        }
    }
}