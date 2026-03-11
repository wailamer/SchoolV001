using System.Xml.Linq;

namespace SchoolV001.Services;

public interface IXmlStorageHelper
{
    XDocument LoadOrCreate(string fileName, string rootName);
    void Save(string fileName, XDocument document);
    string DataPath { get; }
}
