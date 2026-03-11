using System.Xml.Serialization;

namespace SchoolManagement.Web.Services;

public class XmlStorageHelper
{
    private readonly string _basePath;

    public XmlStorageHelper(IConfiguration configuration, IWebHostEnvironment environment)
    {
        var configured = configuration["SchoolXml:BasePath"] ?? "Data/Xml";
        _basePath = Path.Combine(environment.ContentRootPath, configured);
        Directory.CreateDirectory(_basePath);
    }

    public List<T> LoadList<T>(string fileName, string rootName)
    {
        var path = Path.Combine(_basePath, fileName);
        if (!File.Exists(path))
        {
            SaveList(path, rootName, new List<T>());
            return [];
        }

        try
        {
            using var stream = File.OpenRead(path);
            var serializer = new XmlSerializer(typeof(List<T>), new XmlRootAttribute(rootName));
            return (serializer.Deserialize(stream) as List<T>) ?? [];
        }
        catch
        {
            SaveList(path, rootName, new List<T>());
            return [];
        }
    }

    public void SaveList<T>(string fileName, string rootName, List<T> items)
    {
        var path = Path.Combine(_basePath, fileName);
        SaveList(path, rootName, items);
    }

    private static void SaveList<T>(string path, string rootName, List<T> items)
    {
        using var stream = File.Create(path);
        var serializer = new XmlSerializer(typeof(List<T>), new XmlRootAttribute(rootName));
        serializer.Serialize(stream, items);
    }
}
