using SchoolV001.Models.Domain;

namespace SchoolV001.Repositories;

public class SchoolSettingsRepository
{
    public SchoolSettings GetCurrent() => new();
}
