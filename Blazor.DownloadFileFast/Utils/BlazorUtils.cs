using System.Runtime.InteropServices;

namespace Blazor.DownloadFileFast.Utils;

internal static class BlazorUtils
{
    internal static readonly bool IsWASM;

    static BlazorUtils()
    {
        IsWASM = RuntimeInformation.IsOSPlatform(OSPlatform.Create("BROWSER"));
    }
}