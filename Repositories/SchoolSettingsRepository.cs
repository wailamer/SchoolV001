using SchoolManagement.Web.Models.Domain;
using SchoolManagement.Web.Services;

namespace SchoolManagement.Web.Repositories;

public class SchoolSettingsRepository(XmlStorageHelper storage) : ISchoolSettingsRepository
{
    private const string FileName = "school-settings.xml";
    private const string RootName = "SchoolSettings";

    public SchoolSettings Get() => storage.LoadList<SchoolSettings>(FileName, RootName).FirstOrDefault() ?? new SchoolSettings();

    public void Save(SchoolSettings settings) => storage.SaveList(FileName, RootName, [settings]);
}
