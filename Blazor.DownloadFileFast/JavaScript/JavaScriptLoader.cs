using System.Reflection;

namespace Blazor.DownloadFileFast.JavaScript;

internal sealed class JavaScriptLoader
{
    private const string Resource = "Blazor.DownloadFileFast.JavaScript.download.js";
    private const string Resource2 = "Blazor.DownloadFileFast.JavaScript.download2.js";

    public string JavaScript { get; }
    public string JavaScript2 { get; }

    private JavaScriptLoader()
    {
        var assembly = typeof(JavaScriptLoader).GetTypeInfo().Assembly;

        using var stream = assembly.GetManifestResourceStream(Resource)!;
        using var reader = new StreamReader(stream);

        JavaScript = reader.ReadToEnd();

        using var stream2 = assembly.GetManifestResourceStream(Resource2)!;
        using var reader2 = new StreamReader(stream2);

        JavaScript2 = reader2.ReadToEnd();
    }

    public static JavaScriptLoader Instance { get; } = new();
}