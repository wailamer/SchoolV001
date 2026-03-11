using System.Xml.Linq;
using SchoolV001.Models.Domain;
using SchoolV001.Services;

namespace SchoolV001.Repositories;

public class AttendanceRepository(IXmlStorageHelper storage) : IAttendanceRepository
{
    private const string File = "attendance.xml";

    public void SaveBulk(IEnumerable<AttendanceEntry> entries)
    {
        var doc = storage.LoadOrCreate(File, "AttendanceEntries");
        foreach (var e in entries)
        {
            doc.Root!.Add(new XElement("Entry",
                new XElement("Id", e.Id),
                new XElement("StudentRecordId", e.StudentRecordId),
                new XElement("AttendanceDate", e.AttendanceDate),
                new XElement("Status", e.Status),
                new XElement("Notes", e.Notes)));
        }

        storage.Save(File, doc);
    }

    public List<AttendanceEntry> GetByRecord(int recordId) => storage.LoadOrCreate(File, "AttendanceEntries").Root!.Elements("Entry")
        .Where(x => (int?)x.Element("StudentRecordId") == recordId)
        .Select(x => new AttendanceEntry
        {
            Id = (int?)x.Element("Id") ?? 0,
            StudentRecordId = (int?)x.Element("StudentRecordId") ?? 0,
            AttendanceDate = DateOnly.Parse((string?)x.Element("AttendanceDate") ?? DateOnly.FromDateTime(DateTime.Today).ToString("O")),
            Status = (string?)x.Element("Status") ?? "حاضر",
            Notes = (string?)x.Element("Notes") ?? string.Empty
        }).ToList();
}
