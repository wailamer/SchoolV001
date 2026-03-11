using Microsoft.AspNetCore.Mvc;
using SchoolV001.Models.Domain;
using SchoolV001.Models.ViewModels;
using SchoolV001.Repositories;
using SchoolV001.Services;

namespace SchoolV001.Controllers;

public class MarksController : Controller
{
    private readonly SubjectRepository _subjects;
    private readonly SequenceService _sequence;
    private readonly MarkRepository _marks;
    private readonly MarkCalculationService _calc;

    public MarksController(SubjectRepository subjects, SequenceService sequence, MarkRepository marks, MarkCalculationService calc)
    {
        _subjects = subjects;
        _sequence = sequence;
        _marks = marks;
        _calc = calc;
    }

    [HttpGet]
    public IActionResult Entry(int studentRecordId = 0, int semesterNumber = 1)
    {
        var vm = new MarkEntryVm
        {
            StudentRecordId = studentRecordId,
            SemesterNumber = semesterNumber,
            SubjectMarks = _subjects.GetAll().Select(s => new StudentMark
            {
                StudentRecordId = studentRecordId,
                SemesterNumber = semesterNumber,
                SubjectName = s.Name
            }).ToList()
        };

        return View(vm);
    }

    [HttpPost]
    public IActionResult Entry(MarkEntryVm vm)
    {
        foreach (var mark in vm.SubjectMarks)
        {
            mark.Id = _sequence.Next("MarkId");
            mark.StudentRecordId = vm.StudentRecordId;
            mark.SemesterNumber = vm.SemesterNumber;
            _marks.Add(_calc.Calculate(mark));
        }

        TempData["Saved"] = "تم حفظ علامات الفصل بنجاح.";
        return RedirectToAction(nameof(Entry), new { studentRecordId = vm.StudentRecordId, semesterNumber = vm.SemesterNumber });
    }
}
