using Microsoft.AspNetCore.Mvc;
using SchoolV001.Models.Domain;
using SchoolV001.Models.ViewModels;
using SchoolV001.Repositories;
using SchoolV001.Services;

namespace SchoolV001.Controllers;

public class StudentsController(
    IStudentRepository studentRepository,
    IStudentRecordRepository recordRepository,
    ISequenceService sequenceService) : Controller
{
    public IActionResult Index() => View(studentRepository.GetAll());

    [HttpGet]
    public IActionResult Create() => View(new StudentCreateVm());

    [HttpPost]
    public IActionResult Create(StudentCreateVm vm)
    {
        if (!ModelState.IsValid) return View(vm);
        if (studentRepository.ExistsByMinistryCode(vm.MinistryCode))
        {
            ModelState.AddModelError(nameof(vm.MinistryCode), "الكود الوزاري مستخدم مسبقاً.");
            return View(vm);
        }

        var studentId = sequenceService.Next("StudentId");
        var generalRegister = sequenceService.Next("GeneralRegister");
        var student = new StudentRegistration
        {
            Id = studentId,
            GeneralRegisterNumber = generalRegister.ToString("D6"),
            MinistryCode = vm.MinistryCode,
            FirstName = vm.FirstName,
            FatherName = vm.FatherName,
            GrandFatherName = vm.GrandFatherName,
            LastName = vm.LastName,
            MotherName = vm.MotherName,
            BirthDate = vm.BirthDate,
            Phone = vm.Phone,
            Address = vm.Address
        };

        studentRepository.Add(student);
        recordRepository.Add(new StudentRecord
        {
            Id = sequenceService.Next("StudentRecordId"),
            StudentId = studentId,
            AcademicYear = vm.AcademicYear,
            Grade = vm.Grade,
            Section = vm.Section,
            RollNumber = 1,
            EnrollmentDate = DateOnly.FromDateTime(DateTime.Today)
        });

        return RedirectToAction(nameof(Index));
    }
}
