using SchoolV001.Models.Domain;

namespace SchoolV001.Models.ViewModels;

public class PrimaryReportVm
{
    public StudentRegistration Student { get; set; } = new();
    public StudentRecord Record { get; set; } = new();
    public List<StudentMark> Semester1 { get; set; } = [];
    public List<StudentMark> Semester2 { get; set; } = [];
    public decimal YearTotal { get; set; }
    public decimal Percentage { get; set; }
    public string FinalResult { get; set; } = "قيد الدراسة";
}
