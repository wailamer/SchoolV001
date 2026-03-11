using SchoolV001.Models.Domain;
using SchoolV001.Services;

namespace SchoolV001.Repositories;

public class SchoolSettingsRepository(IXmlStorageHelper storage) : ISchoolSettingsRepository
{
    public SchoolSettings Get()
    {
        var node = storage.LoadOrCreate("school-settings.xml", "SchoolSettings").Root;
        return new SchoolSettings
        {
            SchoolNameArabic = (string?)node?.Element("SchoolNameArabic") ?? "مدرسة الياسمين السورية الافتراضية",
            SchoolNameEnglish = (string?)node?.Element("SchoolNameEnglish") ?? "Jasmine Syrian Virtual School",
            Phone = (string?)node?.Element("Phone") ?? string.Empty,
            Address = (string?)node?.Element("Address") ?? string.Empty,
            LogoPath = (string?)node?.Element("LogoPath") ?? string.Empty,
            CurrentAcademicYear = (string?)node?.Element("CurrentAcademicYear") ?? "2025/2026"
        };
    }
}
