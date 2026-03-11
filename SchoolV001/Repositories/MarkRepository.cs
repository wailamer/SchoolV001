using System.Xml.Linq;
using SchoolV001.Models.Domain;
using SchoolV001.Services;

namespace SchoolV001.Repositories;

public class MarkRepository
{
    private readonly XmlStorageHelper _storage;
    private const string FileName = "marks.xml";

    public MarkRepository(XmlStorageHelper storage) => _storage = storage;

    public List<StudentMark> GetByRecord(int studentRecordId, int semester) =>
        LoadAll().Where(x => x.StudentRecordId == studentRecordId && x.SemesterNumber == semester).ToList();

    public void AddMany(IEnumerable<StudentMark> marks)
    {
        var doc = _storage.LoadOrCreate(FileName, "StudentMarks");
        foreach (var mark in marks)
        {
            doc.Root?.Add(new XElement("Mark",
                new XElement("Id", mark.Id),
                new XElement("StudentRecordId", mark.StudentRecordId),
                new XElement("SubjectName", mark.SubjectName),
                new XElement("SemesterNumber", mark.SemesterNumber),
                new XElement("Activities", mark.Activities),
                new XElement("Oral", mark.Oral),
                new XElement("Homework", mark.Homework),
                new XElement("Exam", mark.Exam),
                new XElement("Total", mark.Total),
                new XElement("GradeText", mark.GradeText)));
        }

        _storage.Save(FileName, doc);
    }

    private List<StudentMark> LoadAll()
    {
        var doc = _storage.LoadOrCreate(FileName, "StudentMarks");
        return doc.Root?.Elements("Mark").Select(x => new StudentMark
        {
            Id = (int?)x.Element("Id") ?? 0,
            StudentRecordId = (int?)x.Element("StudentRecordId") ?? 0,
            SubjectName = (string?)x.Element("SubjectName") ?? string.Empty,
            SemesterNumber = (int?)x.Element("SemesterNumber") ?? 1,
            Activities = (decimal?)x.Element("Activities") ?? 0,
            Oral = (decimal?)x.Element("Oral") ?? 0,
            Homework = (decimal?)x.Element("Homework") ?? 0,
            Exam = (decimal?)x.Element("Exam") ?? 0,
            Total = (decimal?)x.Element("Total") ?? 0,
            GradeText = (string?)x.Element("GradeText") ?? string.Empty
        }).ToList() ?? [];
    }
}
