using SchoolManagement.Web.Models.Domain;
using SchoolManagement.Web.Services;

namespace SchoolManagement.Web.Repositories;

public class TeacherRepository(XmlStorageHelper storage, ISequenceService sequenceService) : ITeacherRepository
{
    public IEnumerable<Teacher> GetAll() => storage.LoadList<Teacher>("teachers.xml", "Teachers");

    public Teacher Add(Teacher teacher)
    {
        var items = GetAll().ToList();
        teacher.Id = sequenceService.Next("TeacherId");
        items.Add(teacher);
        storage.SaveList("teachers.xml", "Teachers", items);
        return teacher;
    }
}
