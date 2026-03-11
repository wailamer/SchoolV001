using SchoolV001.Models.Domain;

namespace SchoolV001.Services;

public class PromotionService(ISequenceService sequenceService) : IPromotionService
{
    private static readonly string[] GradeOrder = ["الأول", "الثاني", "الثالث", "الرابع", "الخامس", "السادس", "السابع", "الثامن", "التاسع", "العاشر", "الحادي عشر", "الثاني عشر"];

    public StudentRecord Promote(StudentRecord currentRecord)
    {
        var index = Array.IndexOf(GradeOrder, currentRecord.Grade);
        var nextGrade = index >= 0 && index < GradeOrder.Length - 1 ? GradeOrder[index + 1] : currentRecord.Grade;
        return new StudentRecord
        {
            Id = sequenceService.Next("StudentRecordId"),
            StudentId = currentRecord.StudentId,
            AcademicYear = IncrementAcademicYear(currentRecord.AcademicYear),
            Stage = currentRecord.Stage,
            Cycle = currentRecord.Cycle,
            Grade = nextGrade,
            Section = currentRecord.Section,
            RollNumber = currentRecord.RollNumber,
            EnrollmentDate = DateOnly.FromDateTime(DateTime.Today),
            EnrollmentStatus = "مرفّع",
            ResultStatus = "قيد الدراسة"
        };
    }

    private static string IncrementAcademicYear(string year)
    {
        var p = year.Split('/');
        if (p.Length != 2 || !int.TryParse(p[0], out var y1) || !int.TryParse(p[1], out var y2)) return year;
        return $"{y1 + 1}/{y2 + 1}";
    }
}
