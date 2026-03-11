using System.Xml.Linq;
using SchoolV001.Models.Domain;
using SchoolV001.Services;

namespace SchoolV001.Repositories;

public class MarkRepository(IXmlStorageHelper storage) : IMarkRepository
{
    private const string File = "marks.xml";

    public void SaveBulk(IEnumerable<StudentMark> marks)
    {
        var doc = storage.LoadOrCreate(File, "StudentMarks");
        foreach (var m in marks)
        {
            doc.Root!.Add(new XElement("Mark",
                new XElement("Id", m.Id),
                new XElement("StudentRecordId", m.StudentRecordId),
                new XElement("SubjectName", m.SubjectName),
                new XElement("SemesterNumber", m.SemesterNumber),
                new XElement("Activities", m.Activities),
                new XElement("Oral", m.Oral),
                new XElement("Homework", m.Homework),
                new XElement("Exam", m.Exam),
                new XElement("Total", m.Total),
                new XElement("GradeText", m.GradeText)));
        }

        storage.Save(File, doc);
    }

    public List<StudentMark> GetByRecordAndSemester(int recordId, int semester) => storage.LoadOrCreate(File, "StudentMarks").Root!.Elements("Mark")
        .Where(x => (int?)x.Element("StudentRecordId") == recordId && (int?)x.Element("SemesterNumber") == semester)
        .Select(x => new StudentMark
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
        }).ToList();
}
