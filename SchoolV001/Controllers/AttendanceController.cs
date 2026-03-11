using Microsoft.AspNetCore.Mvc;
using SchoolV001.Models.Domain;
using SchoolV001.Repositories;
using SchoolV001.Services;

namespace SchoolV001.Controllers;

public class AttendanceController : Controller
{
    private readonly AttendanceRepository _attendance;
    private readonly SequenceService _sequences;

    public AttendanceController(AttendanceRepository attendance, SequenceService sequences)
    {
        _attendance = attendance;
        _sequences = sequences;
    }

    public IActionResult Quick() => View(new AttendanceEntry { AttendanceDate = DateTime.Today });

    [HttpPost]
    public IActionResult Quick(AttendanceEntry entry)
    {
        entry.Id = _sequences.Next("AttendanceId");
        _attendance.Add(entry);
        TempData["msg"] = "تم حفظ الدوام";
        return RedirectToAction(nameof(Quick));
    }
}
