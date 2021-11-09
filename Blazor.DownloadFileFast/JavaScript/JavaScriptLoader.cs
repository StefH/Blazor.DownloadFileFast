using System.Reflection;

namespace Blazor.DownloadFileFast.JavaScript;

internal sealed class JavaScriptLoader
{
    private const string Resource = "Blazor.DownloadFileFast.JavaScript.download.js";

    public string JavaScript { get; private set; }

    private JavaScriptLoader()
    {
        var assembly = typeof(JavaScriptLoader).GetTypeInfo().Assembly;

        using var stream = assembly.GetManifestResourceStream(Resource)!;
        using var reader = new StreamReader(stream);

        JavaScript = reader.ReadToEnd();
    }

    public static JavaScriptLoader Instance { get; } = new JavaScriptLoader();
}