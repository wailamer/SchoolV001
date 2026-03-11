namespace SchoolV001.Models.Domain;

public class Teacher
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Mobile { get; set; } = string.Empty;
    public string Qualification { get; set; } = string.Empty;
    public string AssignedGrade { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
}
