using Microsoft.AspNetCore.Mvc;
using SchoolV001.Models.Domain;
using SchoolV001.Models.ViewModels;
using SchoolV001.Repositories;
using SchoolV001.Services;

namespace SchoolV001.Controllers;

public class AttendanceController(
    IStudentRecordRepository recordRepository,
    IStudentRepository studentRepository,
    IAttendanceRepository attendanceRepository,
    ISequenceService sequenceService) : Controller
{
    [HttpGet]
    public IActionResult Index(string grade = "الأول", string section = "1")
    {
        var rows = recordRepository.GetByGradeAndSection(grade, section).Select(r =>
        {
            var student = studentRepository.GetById(r.StudentId);
            return new StudentAttendanceRowVm
            {
                StudentRecordId = r.Id,
                StudentName = student?.FullName ?? $"طالب #{r.StudentId}"
            };
        }).ToList();

        return View(new AttendanceBoardVm { Grade = grade, Section = section, Rows = rows });
    }

    [HttpPost]
    public IActionResult Save(AttendanceBoardVm vm)
    {
        var entries = vm.Rows.Select(r => new AttendanceEntry
        {
            Id = sequenceService.Next("AttendanceId"),
            StudentRecordId = r.StudentRecordId,
            AttendanceDate = vm.Date,
            Status = r.Status,
            Notes = r.Notes
        });
        attendanceRepository.SaveBulk(entries);
        return RedirectToAction(nameof(Index), new { grade = vm.Grade, section = vm.Section });
    }
}
