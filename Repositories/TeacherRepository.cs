using SchoolV001.Models.Domain;
using SchoolV001.Services;

namespace SchoolV001.Repositories;

public class TeacherRepository(IXmlStorageHelper storage) : ITeacherRepository
{
    public List<Teacher> GetAll() => storage.LoadOrCreate("teachers.xml", "Teachers").Root!.Elements("Teacher").Select(x => new Teacher
    {
        Id = (int?)x.Element("Id") ?? 0,
        FullName = (string?)x.Element("FullName") ?? string.Empty,
        Mobile = (string?)x.Element("Mobile") ?? string.Empty,
        Qualification = (string?)x.Element("Qualification") ?? string.Empty,
        AssignedGrade = (string?)x.Element("AssignedGrade") ?? string.Empty,
        IsActive = (bool?)x.Element("IsActive") ?? true
    }).ToList();
}
