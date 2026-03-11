using SchoolV001.Models.Domain;

namespace SchoolV001.Repositories;

public interface IMarkRepository
{
    void SaveBulk(IEnumerable<StudentMark> marks);
    List<StudentMark> GetByRecordAndSemester(int recordId, int semester);
}
