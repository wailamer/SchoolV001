using SchoolV001.Models.Domain;

namespace SchoolV001.Repositories;

public class SubjectRepository
{
    public List<Subject> GetAll()
    {
        return new List<Subject>
        {
            new() { Id = 1, Name = "اللغة العربية", SortOrder = 1 },
            new() { Id = 2, Name = "اللغة الإنجليزية", SortOrder = 2 },
            new() { Id = 3, Name = "الرياضيات", SortOrder = 3 },
            new() { Id = 4, Name = "العلوم العامة", SortOrder = 4 },
            new() { Id = 5, Name = "التربية الوطنية", SortOrder = 5 }
        };
    }
}
