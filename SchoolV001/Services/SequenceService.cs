using System.Xml.Linq;
using SchoolV001.Services;

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
        var seq = doc.Root?.Elements("Sequence").FirstOrDefault(x => (string?)x.Attribute("Key") == key);
        if (seq is null)
        {
            seq = new XElement("Sequence", new XAttribute("Key", key), new XElement("LastNumber", 0));
            doc.Root?.Add(seq);
        }

        var current = (int?)seq.Element("LastNumber") ?? 0;
        current++;
        seq.SetElementValue("LastNumber", current);
        _storage.Save("sequences.xml", doc);
        return current;
    }
}
