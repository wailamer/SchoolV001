using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Web.Models.ViewModels;
using SchoolManagement.Web.Repositories;

namespace SchoolManagement.Web.Controllers;

public class StudentsController(IStudentRepository students, IStudentRecordRepository records) : Controller
{
    public IActionResult Index() => View(students.GetAll().OrderBy(x => x.GeneralRegisterNumber));

    [HttpGet]
    public IActionResult Create() => View(new StudentCreateVm());

    [HttpPost]
    public IActionResult Create(StudentCreateVm vm)
    {
        if (!ModelState.IsValid)
        {
            return View(vm);
        }

        var added = students.Add(vm.Student);
        vm.InitialRecord.StudentId = added.Id;
        records.Add(vm.InitialRecord);
        return RedirectToAction(nameof(Index));
    }
}
