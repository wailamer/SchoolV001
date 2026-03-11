using SchoolV001.Models.Domain;
using SchoolV001.Services;

namespace SchoolV001.Repositories;

public class SubjectRepository(IXmlStorageHelper storage) : ISubjectRepository
{
    public List<Subject> GetAll() => storage.LoadOrCreate("subjects.xml", "Subjects").Root!.Elements("Subject").Select(x => new Subject
    {
        Id = (int?)x.Element("Id") ?? 0,
        Name = (string?)x.Element("Name") ?? string.Empty,
        GradeRange = (string?)x.Element("GradeRange") ?? "1-12",
        IsPrimaryOnly = (bool?)x.Element("IsPrimaryOnly") ?? false,
        SortOrder = (int?)x.Element("SortOrder") ?? 0
    }).OrderBy(x => x.SortOrder).ToList();
}
