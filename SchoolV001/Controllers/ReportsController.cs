using Microsoft.AspNetCore.Mvc;
using SchoolV001.Models.ViewModels;
using SchoolV001.Repositories;

namespace SchoolV001.Controllers;

public class ReportsController : Controller
{
    private readonly StudentRepository _students;
    private readonly StudentRecordRepository _records;
    private readonly MarkRepository _marks;

    public ReportsController(StudentRepository students, StudentRecordRepository records, MarkRepository marks)
    {
        _students = students;
        _records = records;
        _marks = marks;
    }

    public IActionResult Clearance(int studentId)
    {
        var student = _students.GetById(studentId);
        if (student is null) return NotFound();

        var record = _records.LastForStudent(studentId);
        if (record is null) return NotFound();

        var s1 = _marks.GetByRecord(record.Id, 1);
        var s2 = _marks.GetByRecord(record.Id, 2);
        var total = s1.Sum(x => x.Total) + s2.Sum(x => x.Total);
        var max = Math.Max((s1.Count + s2.Count) * 100m, 1m);

        var vm = new PrimaryReportVm
        {
            Student = student,
            Record = record,
            Semester1 = s1,
            Semester2 = s2,
            YearTotal = total,
            Percentage = Math.Round((total / max) * 100m, 2),
            FinalResult = total >= max * 0.5m ? "ناجح" : "راسب"
        };

        return View(vm);
    }
}
