using Microsoft.AspNetCore.Mvc;
using SchoolV001.Models.ViewModels;
using SchoolV001.Repositories;

namespace SchoolV001.Controllers;

public class DashboardController(
    IStudentRepository studentRepository,
    IStudentRecordRepository studentRecordRepository,
    ITeacherRepository teacherRepository,
    ISubjectRepository subjectRepository) : Controller
{
    public IActionResult Index()
    {
        var vm = new DashboardVm
        {
            StudentsCount = studentRepository.GetAll().Count,
            RecordsCount = studentRecordRepository.GetAll().Count,
            TeachersCount = teacherRepository.GetAll().Count,
            SubjectsCount = subjectRepository.GetAll().Count,
            Alerts = ["تأكد من إدخال دوام اليوم.", "راجع درجات الفصل الأول قبل إصدار الجلاء."]
        };
        return View(vm);
    }
}
