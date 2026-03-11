namespace SchoolV001.Models.ViewModels;

public class DashboardVm
{
    public int StudentsCount { get; set; }
    public int AnnualRecordsCount { get; set; }
    public int SubjectsCount { get; set; }
    public int MarksCount { get; set; }
    public List<string> Alerts { get; set; } = new();
}
