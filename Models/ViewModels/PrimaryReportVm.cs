using SchoolV001.Models.Domain;

namespace SchoolV001.Models.ViewModels;

public class PrimaryReportVm
{
    public StudentRegistration Student { get; set; } = new();
    public StudentRecord Record { get; set; } = new();
    public List<StudentMark> SemesterOne { get; set; } = [];
    public List<StudentMark> SemesterTwo { get; set; } = [];
    public int Absences { get; set; }
    public decimal FinalTotal { get; set; }
    public decimal Percentage { get; set; }
    public string ResultText { get; set; } = "ناجح";
}
