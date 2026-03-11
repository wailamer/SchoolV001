namespace SchoolV001.Models.ViewModels;

public class DashboardVm
{
    public int StudentsCount { get; set; }
    public int RecordsCount { get; set; }
    public int TeachersCount { get; set; }
    public int SubjectsCount { get; set; }
    public List<string> Alerts { get; set; } = [];
}
