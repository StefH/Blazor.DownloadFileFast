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

        Task.Run(async () => await _js.InvokeVoidAsync("eval", JavaScriptLoader.Instance.JavaScript));
    }

    /// <see cref="IBlazorDownloadFileService.DownloadFileAsync(string, byte[])"/>
    public ValueTask<bool> DownloadFileAsync(string fileName, byte[] bytes)
    {
        return DownloadFileAsync(fileName, bytes, MimeTypeMap.GetMimeType(fileName));
    }

    /// <see cref="IBlazorDownloadFileService.DownloadFileAsync(string, byte[], string)"/>
    public ValueTask<bool> DownloadFileAsync(string fileName, byte[] bytes, string contentType)
    {
#if NET5_0_OR_GREATER
        // Check if the IJSRuntime is the WebAssembly implementation of the JSRuntime
        if (_js is IJSUnmarshalledRuntime webAssemblyJSRuntime)
        {
            return ValueTask.FromResult(webAssemblyJSRuntime.InvokeUnmarshalled<string, string, byte[], bool>("BlazorDownloadFileFast", fileName, contentType, bytes));
        }

        // Fall back to the slow method if not in WebAssembly
        return BlazorDownloadFileAsync(fileName, bytes, contentType);
#else
        return BlazorDownloadFileAsync(fileName, bytes, contentType);
#endif
    }

    private ValueTask<bool> BlazorDownloadFileAsync(string fileName, byte[] bytes, string contentType)
    {
        return _js.InvokeAsync<bool>("BlazorDownloadFile", fileName, contentType, bytes);
    }
}