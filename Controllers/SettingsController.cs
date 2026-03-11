using Microsoft.AspNetCore.Mvc;
using SchoolV001.Repositories;

namespace SchoolV001.Controllers;

public class SettingsController(ISchoolSettingsRepository schoolSettingsRepository) : Controller
{
    public IActionResult Index() => View(schoolSettingsRepository.Get());
}
