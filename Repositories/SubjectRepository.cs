using SchoolManagement.Web.Models.Domain;
using SchoolManagement.Web.Services;

namespace SchoolManagement.Web.Repositories;

public class SubjectRepository(XmlStorageHelper storage) : ISubjectRepository
{
    public IEnumerable<Subject> GetAll() => storage.LoadList<Subject>("subjects.xml", "Subjects").OrderBy(x => x.SortOrder);
}
