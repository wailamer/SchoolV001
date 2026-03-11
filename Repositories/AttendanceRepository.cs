using SchoolManagement.Web.Models.Domain;
using SchoolManagement.Web.Services;

namespace SchoolManagement.Web.Repositories;

public class AttendanceRepository(XmlStorageHelper storage, ISequenceService sequenceService) : IAttendanceRepository
{
    private const string FileName = "attendance.xml";
    private const string RootName = "AttendanceEntries";

    public IEnumerable<AttendanceEntry> GetByRecordAndDate(int studentRecordId, DateOnly date) =>
        storage.LoadList<AttendanceEntry>(FileName, RootName)
            .Where(x => x.StudentRecordId == studentRecordId && x.AttendanceDate == date);

    public void SaveBatch(IEnumerable<AttendanceEntry> entries)
    {
        var items = storage.LoadList<AttendanceEntry>(FileName, RootName);
        foreach (var entry in entries)
        {
            entry.Id = entry.Id == 0 ? sequenceService.Next("AttendanceId") : entry.Id;
            items.RemoveAll(x => x.StudentRecordId == entry.StudentRecordId && x.AttendanceDate == entry.AttendanceDate);
            items.Add(entry);
        }

        storage.SaveList(FileName, RootName, items);
    }
}
