using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Web.Repositories;

namespace SchoolManagement.Web.Controllers;

public class TeachersController(ITeacherRepository teacherRepository) : Controller
{
    public IActionResult Index() => View(teacherRepository.GetAll());
}
