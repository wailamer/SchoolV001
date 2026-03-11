using Microsoft.AspNetCore.Mvc;
using SchoolV001.Models.ViewModels;
using SchoolV001.Repositories;
using SchoolV001.Services;

namespace SchoolV001.Controllers;

public class StudentsController : Controller
{
    private readonly StudentRepository _students;
    private readonly StudentRecordRepository _records;
    private readonly SequenceService _sequence;

    public StudentsController(StudentRepository students, StudentRecordRepository records, SequenceService sequence)
    {
        _students = students;
        _records = records;
        _sequence = sequence;
    }

    public IActionResult Index()
    {
        var data = _students.GetAll();
        return View(data);
    }

    [HttpGet]
    public IActionResult Create() => View(new StudentCreateVm());

    [HttpPost]
    public IActionResult Create(StudentCreateVm vm)
    {
        vm.Student.Id = _sequence.Next("StudentId");
        vm.Student.GeneralRegisterNumber = _sequence.Next("GeneralRegister").ToString("D6");
        vm.FirstRecord.Id = _sequence.Next("StudentRecordId");
        vm.FirstRecord.StudentId = vm.Student.Id;

        if (string.IsNullOrWhiteSpace(vm.Student.MinistryCode))
        {
            vm.Student.MinistryCode = $"STD-{DateTime.UtcNow.Year}-{vm.Student.Id}";
        }

        _students.Add(vm.Student);
        _records.Add(vm.FirstRecord);
        TempData["Saved"] = "تم حفظ الطالب والسجل السنوي بنجاح.";
        return RedirectToAction(nameof(Index));
    }
}
