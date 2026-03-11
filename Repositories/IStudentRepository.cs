using SchoolV001.Models.Domain;

namespace SchoolV001.Repositories;

public interface IStudentRepository
{
    List<StudentRegistration> GetAll();
    StudentRegistration? GetById(int id);
    void Add(StudentRegistration student);
    bool ExistsByMinistryCode(string ministryCode);
}
