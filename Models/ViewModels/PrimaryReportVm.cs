using SchoolManagement.Web.Models.Domain;

namespace SchoolManagement.Web.Models.ViewModels;

public class PrimaryReportVm
{
    public StudentRegistration Student { get; set; } = new();
    public StudentRecord Record { get; set; } = new();
    public IEnumerable<StudentMark> SemesterOne { get; set; } = [];
    public IEnumerable<StudentMark> SemesterTwo { get; set; } = [];
    public decimal YearTotal { get; set; }
    public decimal Percentage { get; set; }
    public string ResultStatus { get; set; } = string.Empty;
}
