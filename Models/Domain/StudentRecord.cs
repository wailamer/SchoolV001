namespace SchoolManagement.Web.Models.Domain;

public class StudentRecord
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public string AcademicYear { get; set; } = string.Empty;
    public string Stage { get; set; } = string.Empty;
    public string Cycle { get; set; } = string.Empty;
    public string Grade { get; set; } = string.Empty;
    public string Section { get; set; } = string.Empty;
    public int RollNumber { get; set; }
    public DateOnly EnrollmentDate { get; set; }
    public string EnrollmentStatus { get; set; } = "مستجد";
    public string ResultStatus { get; set; } = "قيد الدراسة";
    public int AbsenceCount { get; set; }
    public int TardinessCount { get; set; }
    public string Notes { get; set; } = string.Empty;
}
