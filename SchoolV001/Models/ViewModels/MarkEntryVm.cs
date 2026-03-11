using SchoolV001.Models.Domain;

namespace SchoolV001.Models.ViewModels;

public class MarkEntryVm
{
    public int StudentRecordId { get; set; }
    public int SemesterNumber { get; set; }
    public List<StudentMark> Marks { get; set; } = [];
}
