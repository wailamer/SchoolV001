using SchoolV001.Models.Domain;

namespace SchoolV001.Repositories;

public interface IAttendanceRepository
{
    void SaveBulk(IEnumerable<AttendanceEntry> entries);
    List<AttendanceEntry> GetByRecord(int recordId);
}
