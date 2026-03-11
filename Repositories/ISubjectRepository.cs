using SchoolV001.Models.Domain;

namespace SchoolV001.Repositories;

public interface ISubjectRepository
{
    List<Subject> GetAll();
}
