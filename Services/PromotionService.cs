using SchoolManagement.Web.Models.Domain;

namespace SchoolManagement.Web.Services;

public interface IPromotionService
{
    StudentRecord BuildPromotedRecord(StudentRecord lastRecord, string nextAcademicYear, string nextGrade, int newId);
}

public class PromotionService : IPromotionService
{
    public StudentRecord BuildPromotedRecord(StudentRecord lastRecord, string nextAcademicYear, string nextGrade, int newId)
    {
        return new StudentRecord
        {
            Id = newId,
            StudentId = lastRecord.StudentId,
            AcademicYear = nextAcademicYear,
            Stage = lastRecord.Stage,
            Cycle = lastRecord.Cycle,
            Grade = nextGrade,
            Section = lastRecord.Section,
            RollNumber = lastRecord.RollNumber,
            EnrollmentDate = DateOnly.FromDateTime(DateTime.Today),
            EnrollmentStatus = "مرفّع",
            ResultStatus = "قيد الدراسة"
        };
    }
}
