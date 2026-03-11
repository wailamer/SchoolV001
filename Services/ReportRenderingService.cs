using SchoolManagement.Web.Models.Domain;
using SchoolManagement.Web.Models.ViewModels;

namespace SchoolManagement.Web.Services;

public interface IReportRenderingService
{
    PrimaryReportVm BuildPrimaryReport(StudentRegistration student, StudentRecord record, IEnumerable<StudentMark> marks);
}

public class ReportRenderingService(IMarkCalculationService markCalculationService) : IReportRenderingService
{
    public PrimaryReportVm BuildPrimaryReport(StudentRegistration student, StudentRecord record, IEnumerable<StudentMark> marks)
    {
        var semesterOne = marks.Where(x => x.SemesterNumber == 1).ToList();
        var semesterTwo = marks.Where(x => x.SemesterNumber == 2).ToList();
        var result = markCalculationService.BuildYearResult(semesterOne, semesterTwo);

        return new PrimaryReportVm
        {
            Student = student,
            Record = record,
            SemesterOne = semesterOne,
            SemesterTwo = semesterTwo,
            YearTotal = result.total,
            Percentage = result.percentage,
            ResultStatus = result.result
        };
    }
}
