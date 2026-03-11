using System.Xml.Linq;
using SchoolV001.Models.Domain;
using SchoolV001.Services;

namespace SchoolV001.Repositories;

public class SchoolSettingsRepository
{
    private readonly XmlStorageHelper _storage;

    public SchoolSettingsRepository(XmlStorageHelper storage) => _storage = storage;

    public SchoolSettings Get()
    {
        var doc = _storage.LoadOrCreate("school-settings.xml", "SchoolSettings");
        var root = doc.Root;
        return new SchoolSettings
        {
            SchoolNameArabic = (string?)root?.Element("SchoolNameArabic") ?? "مدرسة الياسمين السورية الافتراضية",
            SchoolNameEnglish = (string?)root?.Element("SchoolNameEnglish") ?? string.Empty,
            Phone = (string?)root?.Element("Phone") ?? string.Empty,
            Address = (string?)root?.Element("Address") ?? string.Empty,
            LogoPath = (string?)root?.Element("LogoPath") ?? string.Empty,
            CurrentAcademicYear = (string?)root?.Element("CurrentAcademicYear") ?? "2025/2026"
        };
    }
}
