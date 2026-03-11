using SchoolV001.Models.Domain;

namespace SchoolV001.Services;

public class PromotionService
{
    public StudentRecord Promote(StudentRecord current, int newId)
    {
        return new StudentRecord
        {
            Id = newId,
            StudentId = current.StudentId,
            AcademicYear = NextYear(current.AcademicYear),
            Stage = current.Stage,
            Cycle = current.Cycle,
            Grade = NextGrade(current.Grade),
            Section = current.Section,
            EnrollmentDate = DateTime.UtcNow,
            EnrollmentStatus = "مرفّع",
            ResultStatus = "قيد الدراسة"
        };
    }

    private static string NextYear(string year)
    {
        var parts = year.Split('/');
        return parts.Length == 2 && int.TryParse(parts[0], out var from) ? $"{from + 1}/{from + 2}" : year;
    }

    private static string NextGrade(string grade)
    {
        var map = new Dictionary<string, string>
        {
            ["الأول"] = "الثاني",
            ["الثاني"] = "الثالث",
            ["الثالث"] = "الرابع",
            ["الرابع"] = "الخامس",
            ["الخامس"] = "السادس",
            ["السادس"] = "السابع",
            ["السابع"] = "الثامن",
            ["الثامن"] = "التاسع",
            ["التاسع"] = "العاشر",
            ["العاشر"] = "الحادي عشر",
            ["الحادي عشر"] = "الثاني عشر"
        };
        return map.GetValueOrDefault(grade, grade);
    }
}
