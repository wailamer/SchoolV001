using SchoolV001.Models.Domain;

namespace SchoolV001.Services;

public interface IMarkCalculationService
{
    StudentMark Calculate(StudentMark mark);
    (decimal total, decimal percentage, string result) FinalizeResult(IEnumerable<StudentMark> semesterOne, IEnumerable<StudentMark> semesterTwo);
}
