using SchoolManagement.Web.Models.Domain;

namespace SchoolManagement.Web.Repositories;

public interface ISubjectRepository
{
    IEnumerable<Subject> GetAll();
}
