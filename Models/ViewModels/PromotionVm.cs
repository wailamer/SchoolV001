namespace SchoolManagement.Web.Models.ViewModels;

public class PromotionVm
{
    public int StudentId { get; set; }
    public int SourceRecordId { get; set; }
    public string NextAcademicYear { get; set; } = string.Empty;
    public string NextGrade { get; set; } = string.Empty;
    public string NextSection { get; set; } = string.Empty;
}
