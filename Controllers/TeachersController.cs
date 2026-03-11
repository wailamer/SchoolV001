using Microsoft.AspNetCore.Mvc;
using SchoolV001.Repositories;

namespace SchoolV001.Controllers;

public class TeachersController(ITeacherRepository teacherRepository) : Controller
{
    public IActionResult Index() => View(teacherRepository.GetAll());
}
