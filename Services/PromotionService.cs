using SchoolV001.Models.Domain;
using SchoolV001.Repositories;

namespace SchoolV001.Services;

public class PromotionService
{
    private readonly StudentRecordRepository _records;
    private readonly SequenceService _sequence;

    public PromotionService(StudentRecordRepository records, SequenceService sequence)
    {
        _records = records;
        _sequence = sequence;
    }

    public StudentRecord Promote(StudentRecord currentRecord, string nextAcademicYear, string nextGrade)
    {
        var newRecord = new StudentRecord
        {
            Id = _sequence.Next("StudentRecordId"),
            StudentId = currentRecord.StudentId,
            AcademicYear = nextAcademicYear,
            Grade = nextGrade,
            Section = currentRecord.Section,
            RollNumber = currentRecord.RollNumber,
            EnrollmentStatus = "مرفّع",
            ResultStatus = "قيد الدراسة",
            Stage = currentRecord.Stage,
            Cycle = currentRecord.Cycle,
            EnrollmentDate = DateTime.UtcNow.Date
        };

        _records.Add(newRecord);
        return newRecord;
    }
}
