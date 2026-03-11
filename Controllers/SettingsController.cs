using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Web.Repositories;

namespace SchoolManagement.Web.Controllers;

public class SettingsController(ISchoolSettingsRepository schoolSettingsRepository) : Controller
{
    [HttpGet]
    public IActionResult Index() => View(schoolSettingsRepository.Get());
}
