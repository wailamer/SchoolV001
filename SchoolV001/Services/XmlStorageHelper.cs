using System.Xml.Linq;

namespace SchoolV001.Services;

public class XmlStorageHelper
{
    private readonly IWebHostEnvironment _environment;

    public XmlStorageHelper(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public string DataPath(string fileName)
    {
        var path = Path.Combine(_environment.ContentRootPath, "Data", fileName);
        Directory.CreateDirectory(Path.GetDirectoryName(path)!);
        return path;
    }

    public XDocument LoadOrCreate(string fileName, string rootName)
    {
        var path = DataPath(fileName);
        if (!File.Exists(path))
        {
            var created = new XDocument(new XElement(rootName));
            created.Save(path);
            return created;
        }

        try
        {
            return XDocument.Load(path);
        }
        catch
        {
            var fallback = new XDocument(new XElement(rootName));
            fallback.Save(path);
            return fallback;
        }
    }

    public void Save(string fileName, XDocument document)
    {
        document.Save(DataPath(fileName));
    }
}
