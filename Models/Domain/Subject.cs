namespace SchoolManagement.Web.Models.Domain;

public class Subject
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string GradeRange { get; set; } = string.Empty;
    public bool IsPrimaryOnly { get; set; }
    public int SortOrder { get; set; }
}
