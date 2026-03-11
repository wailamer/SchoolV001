using SchoolManagement.Web.Models.Domain;

namespace SchoolManagement.Web.Models.ViewModels;

public class StudentCreateVm
{
    public StudentRegistration Student { get; set; } = new();
    public StudentRecord InitialRecord { get; set; } = new();
}
