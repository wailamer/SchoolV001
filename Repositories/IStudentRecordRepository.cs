using SchoolManagement.Web.Models.Domain;

namespace SchoolManagement.Web.Repositories;

public interface IStudentRecordRepository
{
    IEnumerable<StudentRecord> GetAll();
    IEnumerable<StudentRecord> GetByStudentId(int studentId);
    StudentRecord? GetById(int id);
    StudentRecord Add(StudentRecord record);
}
