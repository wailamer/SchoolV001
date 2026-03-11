using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Web.Repositories;

namespace SchoolManagement.Web.Controllers;

public class DashboardController(
    IStudentRepository studentRepository,
    IStudentRecordRepository recordRepository,
    ITeacherRepository teacherRepository,
    ISubjectRepository subjectRepository) : Controller
{
    public IActionResult Index()
    {
        ViewBag.Students = studentRepository.GetAll().Count();
        ViewBag.Records = recordRepository.GetAll().Count();
        ViewBag.Teachers = teacherRepository.GetAll().Count();
        ViewBag.Subjects = subjectRepository.GetAll().Count();
        return View();
    }
}
