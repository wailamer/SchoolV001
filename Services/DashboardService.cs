using SchoolV001.Models.ViewModels;
using SchoolV001.Repositories;

namespace SchoolV001.Services;

public class DashboardService
{
    private readonly StudentRepository _students;
    private readonly StudentRecordRepository _records;
    private readonly SubjectRepository _subjects;
    private readonly MarkRepository _marks;

    public DashboardService(StudentRepository students, StudentRecordRepository records, SubjectRepository subjects, MarkRepository marks)
    {
        _students = students;
        _records = records;
        _subjects = subjects;
        _marks = marks;
    }

    public DashboardVm Build()
    {
        return new DashboardVm
        {
            StudentsCount = _students.GetAll().Count,
            AnnualRecordsCount = _records.GetAll().Count,
            SubjectsCount = _subjects.GetAll().Count,
            MarksCount = _marks.GetAll().Count,
            Alerts = new List<string>
            {
                "تأكد من إدخال علامات الفصل الأول للصفوف العليا.",
                "تم تفعيل بنية XML الآمنة مع fallback تلقائي عند تلف الملف."
            }
        };
    }
}
