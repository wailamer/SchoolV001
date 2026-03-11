using SchoolManagement.Web.Models.Domain;

namespace SchoolManagement.Web.Repositories;

public interface IAttendanceRepository
{
    IEnumerable<AttendanceEntry> GetByRecordAndDate(int studentRecordId, DateOnly date);
    void SaveBatch(IEnumerable<AttendanceEntry> entries);
}
