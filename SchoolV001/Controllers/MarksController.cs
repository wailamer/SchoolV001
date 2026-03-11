using Microsoft.AspNetCore.Mvc;
using SchoolV001.Models.Domain;
using SchoolV001.Models.ViewModels;
using SchoolV001.Repositories;
using SchoolV001.Services;

namespace SchoolV001.Controllers;

public class MarksController : Controller
{
    private readonly MarkRepository _marks;
    private readonly SubjectRepository _subjects;
    private readonly SequenceService _sequences;
    private readonly MarkCalculationService _calculator;

    public MarksController(MarkRepository marks, SubjectRepository subjects, SequenceService sequences, MarkCalculationService calculator)
    {
        _marks = marks;
        _subjects = subjects;
        _sequences = sequences;
        _calculator = calculator;
    }

    public IActionResult Entry(int studentRecordId, int semester = 1)
    {
        var subjects = _subjects.GetDefault();
        var vm = new MarkEntryVm
        {
            StudentRecordId = studentRecordId,
            SemesterNumber = semester,
            Marks = subjects.Select(s => new StudentMark { SubjectName = s.Name, SemesterNumber = semester, StudentRecordId = studentRecordId }).ToList()
        };
        return View(vm);
    }

    [HttpPost]
    public IActionResult Entry(MarkEntryVm vm)
    {
        foreach (var m in vm.Marks)
        {
            m.Id = _sequences.Next("MarkId");
            _calculator.Normalize(m);
        }

        _marks.AddMany(vm.Marks);
        return RedirectToAction("Index", "Students");
    }
}
