using Microsoft.AspNetCore.Mvc;
using SchoolV001.Repositories;

namespace SchoolV001.Controllers;

public class SubjectsController(ISubjectRepository subjectRepository) : Controller
{
    public IActionResult Index() => View(subjectRepository.GetAll());
}
