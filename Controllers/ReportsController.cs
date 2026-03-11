using Microsoft.AspNetCore.Mvc;
using SchoolV001.Models.ViewModels;
using SchoolV001.Repositories;
using SchoolV001.Services;

namespace SchoolV001.Controllers;

public class ReportsController(
    IStudentRecordRepository recordRepository,
    IStudentRepository studentRepository,
    IMarkRepository markRepository,
    IAttendanceRepository attendanceRepository,
    IMarkCalculationService markCalculationService) : Controller
{
    public IActionResult PrimaryClearance(int studentRecordId)
    {
        var record = recordRepository.GetById(studentRecordId);
        if (record is null) return NotFound();
        var student = studentRepository.GetById(record.StudentId);
        if (student is null) return NotFound();

        var sem1 = markRepository.GetByRecordAndSemester(studentRecordId, 1);
        var sem2 = markRepository.GetByRecordAndSemester(studentRecordId, 2);
        var final = markCalculationService.FinalizeResult(sem1, sem2);

        var vm = new PrimaryReportVm
        {
            Student = student,
            Record = record,
            SemesterOne = sem1,
            SemesterTwo = sem2,
            Absences = attendanceRepository.GetByRecord(studentRecordId).Count(x => x.Status == "غائب"),
            FinalTotal = final.total,
            Percentage = final.percentage,
            ResultText = final.result
        };

        return View(vm);
    }
}
