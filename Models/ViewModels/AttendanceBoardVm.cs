using SchoolV001.Models.Domain;

namespace SchoolV001.Models.ViewModels;

public class AttendanceBoardVm
{
    public string Grade { get; set; } = string.Empty;
    public string Section { get; set; } = string.Empty;
    public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Today);
    public List<StudentAttendanceRowVm> Rows { get; set; } = [];
}

public class StudentAttendanceRowVm
{
    public int StudentRecordId { get; set; }
    public string StudentName { get; set; } = string.Empty;
    public string Status { get; set; } = "حاضر";
    public string Notes { get; set; } = string.Empty;
}
