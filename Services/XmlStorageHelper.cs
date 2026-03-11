using System.Xml.Linq;

namespace SchoolV001.Services;

public class XmlStorageHelper
{
    private readonly IWebHostEnvironment _environment;

    public XmlStorageHelper(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public string GetPath(string fileName)
    {
        var folder = Path.Combine(_environment.ContentRootPath, "DataXml");
        Directory.CreateDirectory(folder);
        return Path.Combine(folder, fileName);
    }

    public XDocument LoadOrCreate(string fileName, string rootName)
    {
        var path = GetPath(fileName);
        if (!File.Exists(path))
        {
            var initial = new XDocument(new XElement(rootName));
            initial.Save(path);
            return initial;
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
        document.Save(GetPath(fileName));
    }
}
