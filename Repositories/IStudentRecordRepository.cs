using SchoolV001.Models.Domain;

namespace SchoolV001.Repositories;

public interface IStudentRecordRepository
{
    List<StudentRecord> GetAll();
    List<StudentRecord> GetByGradeAndSection(string grade, string section);
    List<StudentRecord> GetByStudentId(int studentId);
    StudentRecord? GetById(int id);
    void Add(StudentRecord record);
}
