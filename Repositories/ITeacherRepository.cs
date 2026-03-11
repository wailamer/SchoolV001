using SchoolManagement.Web.Models.Domain;

namespace SchoolManagement.Web.Repositories;

public interface ITeacherRepository
{
    IEnumerable<Teacher> GetAll();
    Teacher Add(Teacher teacher);
}
