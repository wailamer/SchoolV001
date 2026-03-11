using SchoolManagement.Web.Models.Domain;

namespace SchoolManagement.Web.Models.ViewModels;

public class MarkEntryVm
{
    public int StudentRecordId { get; set; }
    public int SemesterNumber { get; set; }
    public List<StudentMark> Marks { get; set; } = [];
}
