using SchoolV001.Models.Domain;

namespace SchoolV001.Models.ViewModels;

public class StudentCreateVm
{
    public StudentRegistration Student { get; set; } = new();
    public StudentRecord FirstRecord { get; set; } = new();
}
