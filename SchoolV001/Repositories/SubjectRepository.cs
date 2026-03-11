using SchoolV001.Models.Domain;

namespace SchoolV001.Repositories;

public class SubjectRepository
{
    public List<Subject> GetDefault() =>
    [
        new() { Id = 1, Name = "اللغة العربية", SortOrder = 1 },
        new() { Id = 2, Name = "الرياضيات", SortOrder = 2 },
        new() { Id = 3, Name = "العلوم", SortOrder = 3 },
        new() { Id = 4, Name = "اللغة الإنكليزية", SortOrder = 4 }
    ];
}
