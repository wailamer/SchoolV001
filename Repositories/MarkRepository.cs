using SchoolManagement.Web.Models.Domain;
using SchoolManagement.Web.Services;

namespace SchoolManagement.Web.Repositories;

public class MarkRepository(XmlStorageHelper storage, ISequenceService sequenceService, IMarkCalculationService calculator) : IMarkRepository
{
    private const string FileName = "marks.xml";
    private const string RootName = "StudentMarks";

    public IEnumerable<StudentMark> GetByRecord(int studentRecordId) =>
        storage.LoadList<StudentMark>(FileName, RootName).Where(x => x.StudentRecordId == studentRecordId);

    public void SaveMarks(IEnumerable<StudentMark> marks)
    {
        var items = storage.LoadList<StudentMark>(FileName, RootName);
        foreach (var mark in marks)
        {
            var recalculated = calculator.Recalculate(mark);
            recalculated.Id = recalculated.Id == 0 ? sequenceService.Next("MarkId") : recalculated.Id;
            items.RemoveAll(x => x.StudentRecordId == recalculated.StudentRecordId && x.SemesterNumber == recalculated.SemesterNumber && x.SubjectName == recalculated.SubjectName);
            items.Add(recalculated);
        }

        storage.SaveList(FileName, RootName, items);
    }
}
