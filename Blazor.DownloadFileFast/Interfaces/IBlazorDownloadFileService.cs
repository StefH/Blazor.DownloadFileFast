namespace Blazor.DownloadFileFast.Interfaces;

/// <summary>
/// Interface to download files from Blazor context.
/// </summary>
public interface IBlazorDownloadFileService
{
    /// <summary>
    /// Download bytes as a file from Blazor context to the browser 
    /// </summary>
    /// <param name="fileName">Name of the file. Note that the Content-Type from the file is automatically determined based on the file extension.</param>
    /// <param name="bytes">The file-content.</param>
    ValueTask<bool> DownloadFileAsync(string fileName, byte[] bytes);

    /// <summary>
    /// Download bytes as a file from Blazor context to the browser 
    /// </summary>
    /// <param name="fileName">Name of the file.</param>
    /// <param name="bytes">The file-content.</param>
    /// <param name="contentType">The Content-Type.</param>
    ValueTask<bool> DownloadFileAsync(string fileName, byte[] bytes, string contentType);
}