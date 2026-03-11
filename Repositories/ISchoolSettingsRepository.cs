using SchoolManagement.Web.Models.Domain;

namespace SchoolManagement.Web.Repositories;

public interface ISchoolSettingsRepository
{
    SchoolSettings Get();
    void Save(SchoolSettings settings);
}
