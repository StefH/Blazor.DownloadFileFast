using System.Threading.Tasks;

namespace Blazor.DownloadFile.Interfaces
{
    public interface IBlazorDownloadFileService
    {
        ValueTask<bool> DownloadAsync(string fileName, byte[] bytes);

        ValueTask<bool> DownloadAsync(string fileName, byte[] bytes, string contentType);
    }
}