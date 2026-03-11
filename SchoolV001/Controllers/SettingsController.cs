using Microsoft.AspNetCore.Mvc;
using SchoolV001.Repositories;

namespace SchoolV001.Controllers;

public class SettingsController : Controller
{
    private readonly SchoolSettingsRepository _settings;
    public SettingsController(SchoolSettingsRepository settings) => _settings = settings;

    public IActionResult Index() => View(_settings.Get());
}
