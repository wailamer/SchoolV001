using System.Xml.Linq;

namespace SchoolV001.Services;

public class SequenceService
{
    private readonly XmlStorageHelper _storage;

    public SequenceService(XmlStorageHelper storage)
    {
        _storage = storage;
    }

    public int Next(string key)
    {
        var doc = _storage.LoadOrCreate("sequences.xml", "Sequences");
        var node = doc.Root?.Elements("Sequence").FirstOrDefault(x => (string?)x.Attribute("Key") == key);
        if (node is null)
        {
            node = new XElement("Sequence", new XAttribute("Key", key), new XElement("LastNumber", 0));
            doc.Root?.Add(node);
        }

        var current = (int?)node.Element("LastNumber") ?? 0;
        current++;
        node.SetElementValue("LastNumber", current);
        _storage.Save("sequences.xml", doc);
        return current;
    }
}
