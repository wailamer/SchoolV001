using SchoolV001.Models.Domain;

namespace SchoolV001.Models.ViewModels;

public class MarkEntryVm
{
    public int StudentRecordId { get; set; }
    public int SemesterNumber { get; set; } = 1;
    public List<StudentMark> SubjectMarks { get; set; } = new();
}
