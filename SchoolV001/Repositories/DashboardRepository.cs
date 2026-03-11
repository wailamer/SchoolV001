using SchoolV001.Models.ViewModels;

namespace SchoolV001.Repositories;

public class DashboardRepository
{
    private readonly StudentRepository _students;
    private readonly StudentRecordRepository _records;
    private readonly TeacherRepository _teachers;
    private readonly SubjectRepository _subjects;

    public DashboardRepository(StudentRepository students, StudentRecordRepository records, TeacherRepository teachers, SubjectRepository subjects)
    {
        _students = students;
        _records = records;
        _teachers = teachers;
        _subjects = subjects;
    }

    public DashboardVm Build()
    {
        var vm = new DashboardVm
        {
            StudentsCount = _students.GetAll().Count,
            RecordsCount = _records.GetAll().Count,
            TeachersCount = _teachers.GetDefault().Count,
            SubjectsCount = _subjects.GetDefault().Count
        };

        if (vm.StudentsCount == 0)
            vm.Alerts.Add("لا يوجد طلاب مسجلون بعد");

        if (vm.RecordsCount == 0)
            vm.Alerts.Add("لا توجد سجلات سنوية بعد");

        return vm;
    }
}
