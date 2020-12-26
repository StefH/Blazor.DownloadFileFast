using System.Threading.Tasks;
using Blazor.DownloadFile.Interfaces;
using Blazor.DownloadFile.JavaScript;
using Blazor.DownloadFile.Utils;
using Microsoft.JSInterop;

namespace Blazor.DownloadFile.Services
{
    internal class BlazorDownloadFileService : IBlazorDownloadFileService
    {
        private readonly IJSRuntime _js;

        public BlazorDownloadFileService(IJSRuntime js)
        {
            _js = js;

            Task.Run(async () => await _js.InvokeVoidAsync("eval", JavaScriptLoader.Instance.JavaScript));
        }

        public ValueTask<bool> DownloadAsync(string fileName, byte[] bytes)
        {
            return DownloadAsync(fileName, bytes, MimeTypeMap.GetMimeType(fileName));
        }

        public ValueTask<bool> DownloadAsync(string fileName, byte[] bytes, string contentType)
        {
#if NET5_0
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
}