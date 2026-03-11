using SchoolManagement.Web.Models.Domain;

namespace SchoolManagement.Web.Models.ViewModels;

public class AttendanceBoardVm
{
    public string AcademicYear { get; set; } = string.Empty;
    public string Grade { get; set; } = string.Empty;
    public string Section { get; set; } = string.Empty;
    public DateOnly Date { get; set; }
    public List<StudentRecord> Records { get; set; } = [];
    public List<AttendanceEntry> Entries { get; set; } = [];
}
