using System.ComponentModel.DataAnnotations;

namespace SchoolV001.Models.ViewModels;

public class StudentCreateVm
{
    [Required] public string FirstName { get; set; } = string.Empty;
    [Required] public string FatherName { get; set; } = string.Empty;
    public string GrandFatherName { get; set; } = string.Empty;
    [Required] public string LastName { get; set; } = string.Empty;
    [Required] public string MotherName { get; set; } = string.Empty;
    [Required] public DateOnly BirthDate { get; set; } = DateOnly.FromDateTime(DateTime.Today);
    [Required] public string Grade { get; set; } = "الأول";
    [Required] public string Section { get; set; } = "1";
    [Required] public string AcademicYear { get; set; } = "2025/2026";
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string MinistryCode { get; set; } = string.Empty;
}
