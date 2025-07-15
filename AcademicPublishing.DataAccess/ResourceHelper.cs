using System.Reflection;

namespace AcademicPublishing.DataAccess;

public static class ResourceHelper
{
    public static string ReadSqlEmbeddedResource(string resourceName)
    {
        resourceName = $"AcademicPublishing.DataAccess.Sql.Scripts.{resourceName}.sql";

        var assembly = Assembly.GetExecutingAssembly();
        using var stream = assembly.GetManifestResourceStream(resourceName)
            ?? throw new FileNotFoundException($"Embedded resource '{resourceName}' not found.");

        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
}
