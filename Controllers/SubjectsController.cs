using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Web.Repositories;

namespace SchoolManagement.Web.Controllers;

public class SubjectsController(ISubjectRepository subjectRepository) : Controller
{
    public IActionResult Index() => View(subjectRepository.GetAll());
}
