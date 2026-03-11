namespace SchoolV001.Models.ViewModels;

public class MarkEntryVm
{
    public int StudentRecordId { get; set; }
    public int SemesterNumber { get; set; }
    public List<SubjectMarkVm> SubjectMarks { get; set; } = [];
}

public class SubjectMarkVm
{
    public string SubjectName { get; set; } = string.Empty;
    public decimal Activities { get; set; }
    public decimal Oral { get; set; }
    public decimal Homework { get; set; }
    public decimal Exam { get; set; }
}
