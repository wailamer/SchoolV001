using Microsoft.AspNetCore.Mvc;
using SchoolV001.Models.ViewModels;
using SchoolV001.Repositories;
using SchoolV001.Services;

namespace SchoolV001.Controllers;

public class StudentsController : Controller
{
    private readonly StudentRepository _students;
    private readonly StudentRecordRepository _records;
    private readonly SequenceService _sequences;

    public StudentsController(StudentRepository students, StudentRecordRepository records, SequenceService sequences)
    {
        _students = students;
        _records = records;
        _sequences = sequences;
    }

    public IActionResult Index(string? search)
    {
        var list = _students.GetAll();
        if (!string.IsNullOrWhiteSpace(search))
        {
            list = list.Where(x => x.FullName.Contains(search, StringComparison.OrdinalIgnoreCase)
                                || x.GeneralRegisterNumber.Contains(search)
                                || x.MinistryCode.Contains(search)).ToList();
        }
        return View(list);
    }

    public IActionResult Create() => View(new StudentCreateVm());

    [HttpPost]
    public IActionResult Create(StudentCreateVm vm)
    {
        if (_students.MinistryCodeExists(vm.Student.MinistryCode))
            ModelState.AddModelError("Student.MinistryCode", "الكود الوزاري مستخدم مسبقًا");

        if (!ModelState.IsValid)
            return View(vm);

        vm.Student.Id = _sequences.Next("StudentId");
        vm.Student.GeneralRegisterNumber = _sequences.Next("GeneralRegister").ToString("D6");
        vm.Student.CreatedDate = DateTime.UtcNow;
        _students.Add(vm.Student);

        vm.FirstRecord.Id = _sequences.Next("StudentRecordId");
        vm.FirstRecord.StudentId = vm.Student.Id;
        vm.FirstRecord.EnrollmentStatus = "مستجد";
        vm.FirstRecord.ResultStatus = "قيد الدراسة";
        _records.Add(vm.FirstRecord);

        return RedirectToAction(nameof(Index));
    }
}
