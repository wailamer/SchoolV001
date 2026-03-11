using System.Xml.Linq;

namespace SchoolV001.Services;

public class SequenceService(IXmlStorageHelper storage) : ISequenceService
{
    private const string File = "sequences.xml";

    public int Next(string key)
    {
        var doc = storage.LoadOrCreate(File, "Sequences");
        var sequence = doc.Root?.Elements("Sequence").FirstOrDefault(x => (string?)x.Attribute("Key") == key);
        if (sequence is null)
        {
            sequence = new XElement("Sequence",
                new XAttribute("Key", key),
                new XElement("LastNumber", 0));
            doc.Root?.Add(sequence);
        }

        var last = (int?)sequence.Element("LastNumber") ?? 0;
        var next = last + 1;
        sequence.Element("LastNumber")!.Value = next.ToString();
        storage.Save(File, doc);
        return next;
    }
}
