using SchoolManagement.Web.Models.Domain;

namespace SchoolManagement.Web.Repositories;

public interface IMarkRepository
{
    IEnumerable<StudentMark> GetByRecord(int studentRecordId);
    void SaveMarks(IEnumerable<StudentMark> marks);
}
