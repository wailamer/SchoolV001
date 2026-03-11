using SchoolV001.Models.Domain;

namespace SchoolV001.Models.ViewModels;

public class PrimaryReportVm
{
    public StudentRegistration Student { get; set; } = new();
    public StudentRecord Record { get; set; } = new();
    public SchoolSettings Settings { get; set; } = new();
    public List<StudentMark> Semester1 { get; set; } = new();
    public List<StudentMark> Semester2 { get; set; } = new();
    public decimal FinalTotal { get; set; }
    public decimal FinalPercentage { get; set; }
    public string FinalResult { get; set; } = "ناجح";
    public string Guidance { get; set; } = "يُنصح بالاستمرار بنفس الجهد والالتزام.";
}
