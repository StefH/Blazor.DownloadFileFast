using System.Reflection;

namespace Blazor.DownloadFileFast.JavaScript;

internal sealed class EmbeddedFileLoader
{
    private const string Resource = "Blazor.DownloadFileFast.JavaScript.download.js";

    public string DownloadJS { get; }

    private EmbeddedFileLoader()
    {
        var assembly = typeof(EmbeddedFileLoader).GetTypeInfo().Assembly;

        using var stream = assembly.GetManifestResourceStream(Resource)!;
        using var reader = new StreamReader(stream);

        DownloadJS = reader.ReadToEnd();
    }

    public static EmbeddedFileLoader Instance { get; } = new();
}