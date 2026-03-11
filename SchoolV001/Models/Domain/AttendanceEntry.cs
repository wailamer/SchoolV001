namespace SchoolV001.Models.Domain;

public class AttendanceEntry
{
    public int Id { get; set; }
    public int StudentRecordId { get; set; }
    public DateTime AttendanceDate { get; set; }
    public string Status { get; set; } = "حاضر";
    public string Notes { get; set; } = string.Empty;
}
