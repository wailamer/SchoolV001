using Microsoft.AspNetCore.Mvc;

namespace SchoolManagement.Web.Controllers;

public class AttendanceController : Controller
{
    public IActionResult Index() => View();
}
