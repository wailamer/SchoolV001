namespace SchoolV001.Models.Domain;

public class SchoolSettings
{
    public string SchoolNameArabic { get; set; } = "مدرسة الياسمين السورية الافتراضية";
    public string SchoolNameEnglish { get; set; } = "Jasmine Syrian Virtual School";
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string LogoPath { get; set; } = string.Empty;
    public string CurrentAcademicYear { get; set; } = "2025/2026";
}
