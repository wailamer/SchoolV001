using SchoolV001.Models.Domain;

namespace SchoolV001.Repositories;

public class TeacherRepository
{
    public List<Teacher> GetDefault() => [new() { Id = 1, FullName = "المعلم الافتراضي", AssignedGrade = "الرابع" }];
}
