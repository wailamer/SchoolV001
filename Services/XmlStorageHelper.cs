using System.Xml.Linq;

namespace SchoolV001.Services;

public class XmlStorageHelper(IWebHostEnvironment env) : IXmlStorageHelper
{
    public string DataPath => Path.Combine(env.ContentRootPath, "DataXml");

    public XDocument LoadOrCreate(string fileName, string rootName)
    {
        Directory.CreateDirectory(DataPath);
        var fullPath = Path.Combine(DataPath, fileName);
        if (!File.Exists(fullPath))
        {
            var created = new XDocument(new XElement(rootName));
            created.Save(fullPath);
            return created;
        }

        try
        {
            return XDocument.Load(fullPath);
        }
        catch
        {
            var fallback = new XDocument(new XElement(rootName));
            fallback.Save(fullPath);
            return fallback;
        }
    }

    public void Save(string fileName, XDocument document)
    {
        Directory.CreateDirectory(DataPath);
        document.Save(Path.Combine(DataPath, fileName));
    }
}
