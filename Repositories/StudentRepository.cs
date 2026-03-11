using System.Xml.Linq;
using SchoolV001.Models.Domain;
using SchoolV001.Services;

namespace SchoolV001.Repositories;

public class StudentRepository(IXmlStorageHelper storage) : IStudentRepository
{
    private const string File = "students.xml";

    public List<StudentRegistration> GetAll() => storage.LoadOrCreate(File, "StudentRegistrations").Root!
        .Elements("Student")
        .Select(x => new StudentRegistration
        {
            Id = (int?)x.Element("Id") ?? 0,
            GeneralRegisterNumber = (string?)x.Element("GeneralRegisterNumber") ?? string.Empty,
            MinistryCode = (string?)x.Element("MinistryCode") ?? string.Empty,
            FirstName = (string?)x.Element("FirstName") ?? string.Empty,
            FatherName = (string?)x.Element("FatherName") ?? string.Empty,
            GrandFatherName = (string?)x.Element("GrandFatherName") ?? string.Empty,
            LastName = (string?)x.Element("LastName") ?? string.Empty,
            MotherName = (string?)x.Element("MotherName") ?? string.Empty,
            BirthDate = DateOnly.Parse((string?)x.Element("BirthDate") ?? DateOnly.FromDateTime(DateTime.Today).ToString("O")),
            Phone = (string?)x.Element("Phone") ?? string.Empty,
            Address = (string?)x.Element("Address") ?? string.Empty
        }).ToList();

    public StudentRegistration? GetById(int id) => GetAll().FirstOrDefault(x => x.Id == id);

    public bool ExistsByMinistryCode(string ministryCode) => GetAll().Any(x => x.MinistryCode == ministryCode && !string.IsNullOrWhiteSpace(ministryCode));

    public void Add(StudentRegistration student)
    {
        var doc = storage.LoadOrCreate(File, "StudentRegistrations");
        doc.Root!.Add(new XElement("Student",
            new XElement("Id", student.Id),
            new XElement("GeneralRegisterNumber", student.GeneralRegisterNumber),
            new XElement("MinistryCode", student.MinistryCode),
            new XElement("FirstName", student.FirstName),
            new XElement("FatherName", student.FatherName),
            new XElement("GrandFatherName", student.GrandFatherName),
            new XElement("LastName", student.LastName),
            new XElement("MotherName", student.MotherName),
            new XElement("BirthDate", student.BirthDate),
            new XElement("Phone", student.Phone),
            new XElement("Address", student.Address)));
        storage.Save(File, doc);
    }
}
