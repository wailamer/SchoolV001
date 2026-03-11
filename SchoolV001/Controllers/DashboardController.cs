using Microsoft.AspNetCore.Mvc;
using SchoolV001.Repositories;

namespace SchoolV001.Controllers;

public class DashboardController : Controller
{
    private readonly DashboardRepository _dashboard;

    public DashboardController(DashboardRepository dashboard) => _dashboard = dashboard;

    public IActionResult Index() => View(_dashboard.Build());
}
