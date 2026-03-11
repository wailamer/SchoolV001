using Microsoft.AspNetCore.Mvc;

namespace SchoolManagement.Web.Controllers;

public class ClassesController : Controller
{
    public IActionResult Index() => View();
}
