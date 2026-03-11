using System.Xml.Linq;
using SchoolV001.Models.Domain;
using SchoolV001.Services;

namespace SchoolV001.Repositories;

public class StudentRecordRepository
{
    private readonly XmlStorageHelper _storage;

    public StudentRecordRepository(XmlStorageHelper storage) => _storage = storage;

    public List<StudentRecord> GetAll()
    {
        var doc = _storage.LoadOrCreate("student-records.xml", "StudentRecords");
        return doc.Root!.Elements("Record").Select(x => new StudentRecord
        {
            Id = (int?)x.Element("Id") ?? 0,
            StudentId = (int?)x.Element("StudentId") ?? 0,
            AcademicYear = (string?)x.Element("AcademicYear") ?? string.Empty,
            Stage = (string?)x.Element("Stage") ?? string.Empty,
            Cycle = (string?)x.Element("Cycle") ?? string.Empty,
            Grade = (string?)x.Element("Grade") ?? string.Empty,
            Section = (string?)x.Element("Section") ?? string.Empty,
            RollNumber = (int?)x.Element("RollNumber") ?? 0,
            EnrollmentStatus = (string?)x.Element("EnrollmentStatus") ?? string.Empty,
            ResultStatus = (string?)x.Element("ResultStatus") ?? string.Empty,
            AbsenceCount = (int?)x.Element("AbsenceCount") ?? 0,
            TardinessCount = (int?)x.Element("TardinessCount") ?? 0
        }).ToList();
    }

    public StudentRecord? Get(int id) => GetAll().FirstOrDefault(r => r.Id == id);

    public StudentRecord? GetLatestForStudent(int studentId) => GetAll()
        .Where(x => x.StudentId == studentId)
        .OrderByDescending(x => x.Id)
        .FirstOrDefault();

    public void Add(StudentRecord record)
    {
        var doc = _storage.LoadOrCreate("student-records.xml", "StudentRecords");
        doc.Root!.Add(new XElement("Record",
            new XElement("Id", record.Id),
            new XElement("StudentId", record.StudentId),
            new XElement("AcademicYear", record.AcademicYear),
            new XElement("Stage", record.Stage),
            new XElement("Cycle", record.Cycle),
            new XElement("Grade", record.Grade),
            new XElement("Section", record.Section),
            new XElement("RollNumber", record.RollNumber),
            new XElement("EnrollmentDate", record.EnrollmentDate.ToString("yyyy-MM-dd")),
            new XElement("EnrollmentStatus", record.EnrollmentStatus),
            new XElement("ResultStatus", record.ResultStatus),
            new XElement("AbsenceCount", record.AbsenceCount),
            new XElement("TardinessCount", record.TardinessCount),
            new XElement("Notes", record.Notes)
        ));
        _storage.Save("student-records.xml", doc);
    }
}
