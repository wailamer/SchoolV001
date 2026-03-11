using System.Xml.Linq;
using SchoolV001.Models.Domain;
using SchoolV001.Services;

namespace SchoolV001.Repositories;

public class StudentRecordRepository(IXmlStorageHelper storage) : IStudentRecordRepository
{
    private const string File = "student-records.xml";

    public List<StudentRecord> GetAll() => storage.LoadOrCreate(File, "StudentRecords").Root!.Elements("Record").Select(x => new StudentRecord
    {
        Id = (int?)x.Element("Id") ?? 0,
        StudentId = (int?)x.Element("StudentId") ?? 0,
        AcademicYear = (string?)x.Element("AcademicYear") ?? string.Empty,
        Grade = (string?)x.Element("Grade") ?? string.Empty,
        Section = (string?)x.Element("Section") ?? string.Empty,
        RollNumber = (int?)x.Element("RollNumber") ?? 0,
        EnrollmentDate = DateOnly.Parse((string?)x.Element("EnrollmentDate") ?? DateOnly.FromDateTime(DateTime.Today).ToString("O")),
        EnrollmentStatus = (string?)x.Element("EnrollmentStatus") ?? string.Empty,
        ResultStatus = (string?)x.Element("ResultStatus") ?? string.Empty,
        AbsenceCount = (int?)x.Element("AbsenceCount") ?? 0,
        TardinessCount = (int?)x.Element("TardinessCount") ?? 0
    }).ToList();

    public List<StudentRecord> GetByGradeAndSection(string grade, string section) => GetAll().Where(x => x.Grade == grade && x.Section == section).ToList();
    public List<StudentRecord> GetByStudentId(int studentId) => GetAll().Where(x => x.StudentId == studentId).ToList();
    public StudentRecord? GetById(int id) => GetAll().FirstOrDefault(x => x.Id == id);

    public void Add(StudentRecord record)
    {
        var doc = storage.LoadOrCreate(File, "StudentRecords");
        doc.Root!.Add(new XElement("Record",
            new XElement("Id", record.Id),
            new XElement("StudentId", record.StudentId),
            new XElement("AcademicYear", record.AcademicYear),
            new XElement("Stage", record.Stage),
            new XElement("Cycle", record.Cycle),
            new XElement("Grade", record.Grade),
            new XElement("Section", record.Section),
            new XElement("RollNumber", record.RollNumber),
            new XElement("EnrollmentDate", record.EnrollmentDate),
            new XElement("EnrollmentStatus", record.EnrollmentStatus),
            new XElement("ResultStatus", record.ResultStatus),
            new XElement("AbsenceCount", record.AbsenceCount),
            new XElement("TardinessCount", record.TardinessCount),
            new XElement("Notes", record.Notes)));
        storage.Save(File, doc);
    }
}
