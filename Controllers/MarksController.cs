using Microsoft.AspNetCore.Mvc;
using SchoolV001.Models.Domain;
using SchoolV001.Models.ViewModels;
using SchoolV001.Repositories;
using SchoolV001.Services;

namespace SchoolV001.Controllers;

public class MarksController(
    ISubjectRepository subjectRepository,
    IMarkRepository markRepository,
    IMarkCalculationService markCalculationService,
    ISequenceService sequenceService) : Controller
{
    [HttpGet]
    public IActionResult Entry(int studentRecordId = 1, int semesterNumber = 1)
    {
        var vm = new MarkEntryVm
        {
            StudentRecordId = studentRecordId,
            SemesterNumber = semesterNumber,
            SubjectMarks = subjectRepository.GetAll().Take(8).Select(x => new SubjectMarkVm { SubjectName = x.Name }).ToList()
        };
        return View(vm);
    }

    [HttpPost]
    public IActionResult Entry(MarkEntryVm vm)
    {
        var marks = vm.SubjectMarks.Select(s => markCalculationService.Calculate(new StudentMark
        {
            Id = sequenceService.Next("MarkId"),
            StudentRecordId = vm.StudentRecordId,
            SemesterNumber = vm.SemesterNumber,
            SubjectName = s.SubjectName,
            Activities = s.Activities,
            Oral = s.Oral,
            Homework = s.Homework,
            Exam = s.Exam
        })).ToList();

        markRepository.SaveBulk(marks);
        return RedirectToAction("PrimaryClearance", "Reports", new { studentRecordId = vm.StudentRecordId });
    }
}
