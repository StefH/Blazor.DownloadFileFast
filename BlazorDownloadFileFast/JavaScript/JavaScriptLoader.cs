using System.IO;
using System.Reflection;

namespace Blazor.DownloadFile.JavaScript
{
    internal static class JavaScriptLoader
    {
        private const string Resource = "Blazor.DownloadFile.JavaScript.download.js";

        public static string Load()
        {
            var assembly = typeof(JavaScriptLoader).GetTypeInfo().Assembly;

            using (var stream = assembly.GetManifestResourceStream(Resource))
            {
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}