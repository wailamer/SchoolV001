using SchoolManagement.Web.Models.Domain;

namespace SchoolManagement.Web.Repositories;

public interface IStudentRepository
{
    IEnumerable<StudentRegistration> GetAll();
    StudentRegistration? GetById(int id);
    StudentRegistration Add(StudentRegistration student);
    void Update(StudentRegistration student);
    bool MinistryCodeExists(string ministryCode, int? excludingId = null);
}
