using System.Xml.Linq;
using SchoolV001.Models.Domain;
using SchoolV001.Services;

namespace SchoolV001.Repositories;

public class AttendanceRepository
{
    private readonly XmlStorageHelper _storage;
    private const string FileName = "attendance.xml";

    public AttendanceRepository(XmlStorageHelper storage) => _storage = storage;

    public void Add(AttendanceEntry entry)
    {
        var doc = _storage.LoadOrCreate(FileName, "AttendanceEntries");
        doc.Root?.Add(new XElement("Entry",
            new XElement("Id", entry.Id),
            new XElement("StudentRecordId", entry.StudentRecordId),
            new XElement("AttendanceDate", entry.AttendanceDate.ToString("yyyy-MM-dd")),
            new XElement("Status", entry.Status),
            new XElement("Notes", entry.Notes)));
        _storage.Save(FileName, doc);
    }
}
