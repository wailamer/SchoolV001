using Microsoft.AspNetCore.Mvc;
using SchoolV001.Models.ViewModels;
using SchoolV001.Repositories;

namespace SchoolV001.Controllers;

public class ClassesController(IStudentRecordRepository recordRepository) : Controller
{
    public IActionResult Index()
    {
        var vm = recordRepository.GetAll()
            .GroupBy(x => new { x.Grade, x.Section })
            .Select(x => new ClassGroupVm { Grade = x.Key.Grade, Section = x.Key.Section, StudentsCount = x.Count() })
            .ToList();
        return View(vm);
    }
}
