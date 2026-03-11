using Microsoft.AspNetCore.Mvc;
using SchoolV001.Models.ViewModels;
using SchoolV001.Repositories;

namespace SchoolV001.Controllers;

public class ReportsController : Controller
{
    private readonly StudentRepository _students;
    private readonly StudentRecordRepository _records;
    private readonly MarkRepository _marks;
    private readonly SchoolSettingsRepository _settings;

    public ReportsController(StudentRepository students, StudentRecordRepository records, MarkRepository marks, SchoolSettingsRepository settings)
    {
        _students = students;
        _records = records;
        _marks = marks;
        _settings = settings;
    }

    public IActionResult PrimaryClearance(int studentId)
    {
        var student = _students.Get(studentId);
        if (student is null) return NotFound();

        var record = _records.GetLatestForStudent(studentId);
        if (record is null) return NotFound();

        var sem1 = _marks.GetByRecordAndSemester(record.Id, 1);
        var sem2 = _marks.GetByRecordAndSemester(record.Id, 2);

        var finalTotal = sem1.Sum(x => x.Total) + sem2.Sum(x => x.Total);
        var finalMax = Math.Max((sem1.Count + sem2.Count) * 200m, 1m);
        var percentage = Math.Round((finalTotal / finalMax) * 100m, 2);

        var vm = new PrimaryReportVm
        {
            Student = student,
            Record = record,
            Settings = _settings.GetCurrent(),
            Semester1 = sem1,
            Semester2 = sem2,
            FinalTotal = finalTotal,
            FinalPercentage = percentage,
            FinalResult = percentage >= 50 ? "ناجح" : "راسب"
        };

        return View(vm);
    }

    public IActionResult SemesterSheet(int studentId)
    {
        var student = _students.Get(studentId);
        if (student is null) return NotFound();
        var record = _records.GetLatestForStudent(studentId);
        if (record is null) return NotFound();

        var sem1 = _marks.GetByRecordAndSemester(record.Id, 1);
        var total = sem1.Sum(x => x.Total);
        var percentage = sem1.Count == 0 ? 0 : Math.Round((total / (sem1.Count * 200m)) * 100m, 2);

        ViewBag.StudentName = student.FullName;
        ViewBag.Total = total;
        ViewBag.Percentage = percentage;
        return View(sem1);
    }
}
