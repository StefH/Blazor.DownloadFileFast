#if NET7_0_OR_GREATER
using System.Runtime.InteropServices.JavaScript;
#endif
using Blazor.DownloadFileFast.JavaScript;
using Microsoft.JSInterop;

namespace Blazor.DownloadFileFast.Services;

internal class BlazorDownloadFileService : IBlazorDownloadFileService
{
    private readonly IJSRuntime _js;

    /// <summary>
    /// Initializes a new instance of the <see cref="BlazorDownloadFileService"/> class.
    /// </summary>
    /// <param name="js">The JSRuntime.</param>
    public BlazorDownloadFileService(IJSRuntime js)
    {
        _js = js;

#if NET7_0_OR_GREATER
        if (BlazorUtils.IsWASM)
        {
#pragma warning disable CA1416
            Task.Run(async () => await JSHost.ImportAsync("download.js", "/_content/BlazorDownloadFileFast/download7up.js"));
#pragma warning restore CA1416
            return;
        }
#endif
        Task.Run(async () => await _js.InvokeVoidAsync("eval", EmbeddedFileLoader.Instance.DownloadJS));
    }

    /// <inheritdoc />
    public ValueTask<bool> DownloadFileAsync(string fileName, byte[] bytes)
    {
        return DownloadFileAsync(fileName, bytes, MimeTypeMap.GetMimeType(fileName));
    }

    /// <inheritdoc />
    public ValueTask<bool> DownloadFileAsync(string fileName, byte[] bytes, string contentType)
    {
        if (BlazorUtils.IsWASM)
        {
#if NET5_0 || NET6_0
            // Check if the IJSRuntime is the WebAssembly implementation of the JSRuntime
            if (_js is IJSUnmarshalledRuntime webAssemblyJSRuntime)
            {
                return ValueTask.FromResult(webAssemblyJSRuntime.InvokeUnmarshalled<string, string, byte[], bool>("BlazorDownloadFileFast", fileName, contentType, bytes));
            }
#else
            // Use 7Up version
            return ValueTask.FromResult(BlazorDownloadFileInterop.BlazorDownloadFileFast(fileName, contentType, bytes));
#endif
        }

        // Fall back to the slow method if not in WebAssembly
        return BlazorDownloadFileAsync(fileName, bytes, contentType);
    }

    private ValueTask<bool> BlazorDownloadFileAsync(string fileName, byte[] bytes, string contentType)
    {
        return _js.InvokeAsync<bool>("BlazorDownloadFile", fileName, contentType, bytes);
    }
}

#if NET7_0_OR_GREATER
// - https://linkdotnet.github.io/tips-and-tricks/blazor/#use-jsimport-or-jsexport-attributes-to-simplify-the-interop
// - https://devblogs.microsoft.com/dotnet/use-net-7-from-any-javascript-app-in-net-7/
public static partial class BlazorDownloadFileInterop
{
    [JSImport("BlazorDownloadFileFast7Up", "download.js")]
    internal static partial bool BlazorDownloadFileFast(string fileName, string contentType, byte[] data);
}
#endif