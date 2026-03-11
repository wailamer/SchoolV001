namespace SchoolV001.Models.Domain;

public class StudentMark
{
    public int Id { get; set; }
    public int StudentRecordId { get; set; }
    public string SubjectName { get; set; } = string.Empty;
    public int SemesterNumber { get; set; }
    public decimal Activities { get; set; }
    public decimal Oral { get; set; }
    public decimal Homework { get; set; }
    public decimal Exam { get; set; }
    public decimal Total { get; set; }
    public string GradeText { get; set; } = string.Empty;
}
