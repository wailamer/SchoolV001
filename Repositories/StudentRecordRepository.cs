using SchoolManagement.Web.Models.Domain;
using SchoolManagement.Web.Services;

namespace SchoolManagement.Web.Repositories;

public class StudentRecordRepository(XmlStorageHelper storage, ISequenceService sequenceService) : IStudentRecordRepository
{
    private const string FileName = "student-records.xml";
    private const string RootName = "StudentRecords";

    public IEnumerable<StudentRecord> GetAll() => storage.LoadList<StudentRecord>(FileName, RootName);

    public IEnumerable<StudentRecord> GetByStudentId(int studentId) => GetAll().Where(x => x.StudentId == studentId);

    public StudentRecord? GetById(int id) => GetAll().FirstOrDefault(x => x.Id == id);

    public StudentRecord Add(StudentRecord record)
    {
        var items = storage.LoadList<StudentRecord>(FileName, RootName);
        record.Id = sequenceService.Next("StudentRecordId");
        items.Add(record);
        storage.SaveList(FileName, RootName, items);
        return record;
    }
}
