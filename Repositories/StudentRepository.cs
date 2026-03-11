using SchoolManagement.Web.Models.Domain;
using SchoolManagement.Web.Services;

namespace SchoolManagement.Web.Repositories;

public class StudentRepository(XmlStorageHelper storage, ISequenceService sequenceService) : IStudentRepository
{
    private const string FileName = "students.xml";
    private const string RootName = "StudentRegistrations";

    public IEnumerable<StudentRegistration> GetAll() => storage.LoadList<StudentRegistration>(FileName, RootName);

    public StudentRegistration? GetById(int id) => GetAll().FirstOrDefault(x => x.Id == id);

    public StudentRegistration Add(StudentRegistration student)
    {
        var items = storage.LoadList<StudentRegistration>(FileName, RootName);
        if (MinistryCodeExists(student.MinistryCode))
        {
            throw new InvalidOperationException("الكود الوزاري مستخدم مسبقاً");
        }

        student.Id = sequenceService.Next("StudentId");
        student.GeneralRegisterNumber = sequenceService.Next("GeneralRegister").ToString("D6");
        student.CreatedDate = DateOnly.FromDateTime(DateTime.Today);
        items.Add(student);
        storage.SaveList(FileName, RootName, items);
        return student;
    }

    public void Update(StudentRegistration student)
    {
        var items = storage.LoadList<StudentRegistration>(FileName, RootName);
        var index = items.FindIndex(x => x.Id == student.Id);
        if (index < 0)
        {
            return;
        }

        items[index] = student;
        storage.SaveList(FileName, RootName, items);
    }

    public bool MinistryCodeExists(string ministryCode, int? excludingId = null) =>
        GetAll().Any(x => x.MinistryCode == ministryCode && (!excludingId.HasValue || x.Id != excludingId));
}
