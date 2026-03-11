using Microsoft.AspNetCore.Mvc;
using SchoolV001.Services;

namespace SchoolV001.Controllers;

public class DashboardController : Controller
{
    private readonly DashboardService _dashboard;

    public DashboardController(DashboardService dashboard)
    {
        _dashboard = dashboard;
    }

    public IActionResult Index()
    {
        return View(_dashboard.Build());
    }
}
