using System.Xml.Linq;
using SchoolV001.Models.Domain;
using SchoolV001.Services;

namespace SchoolV001.Repositories;

public class StudentRepository
{
    private readonly XmlStorageHelper _storage;

    public StudentRepository(XmlStorageHelper storage) => _storage = storage;

    public List<StudentRegistration> GetAll()
    {
        var doc = _storage.LoadOrCreate("students.xml", "StudentRegistrations");
        return doc.Root!.Elements("Student").Select(x => new StudentRegistration
        {
            Id = (int?)x.Element("Id") ?? 0,
            GeneralRegisterNumber = (string?)x.Element("GeneralRegisterNumber") ?? string.Empty,
            MinistryCode = (string?)x.Element("MinistryCode") ?? string.Empty,
            FirstName = (string?)x.Element("FirstName") ?? string.Empty,
            FatherName = (string?)x.Element("FatherName") ?? string.Empty,
            GrandFatherName = (string?)x.Element("GrandFatherName") ?? string.Empty,
            LastName = (string?)x.Element("LastName") ?? string.Empty,
            MotherName = (string?)x.Element("MotherName") ?? string.Empty,
            BirthDate = DateTime.TryParse((string?)x.Element("BirthDate"), out var birthDate) ? birthDate : DateTime.UtcNow.Date,
            BirthPlace = (string?)x.Element("BirthPlace") ?? string.Empty,
            Phone = (string?)x.Element("Phone") ?? string.Empty,
            Address = (string?)x.Element("Address") ?? string.Empty,
            IsActive = (bool?)x.Element("IsActive") ?? true,
        }).ToList();
    }

    public StudentRegistration? Get(int id) => GetAll().FirstOrDefault(s => s.Id == id);

    public void Add(StudentRegistration student)
    {
        var doc = _storage.LoadOrCreate("students.xml", "StudentRegistrations");
        doc.Root!.Add(new XElement("Student",
            new XElement("Id", student.Id),
            new XElement("GeneralRegisterNumber", student.GeneralRegisterNumber),
            new XElement("MinistryCode", student.MinistryCode),
            new XElement("FirstName", student.FirstName),
            new XElement("FatherName", student.FatherName),
            new XElement("GrandFatherName", student.GrandFatherName),
            new XElement("LastName", student.LastName),
            new XElement("MotherName", student.MotherName),
            new XElement("BirthDate", student.BirthDate.ToString("yyyy-MM-dd")),
            new XElement("BirthPlace", student.BirthPlace),
            new XElement("Phone", student.Phone),
            new XElement("Address", student.Address),
            new XElement("IsActive", student.IsActive)
        ));
        _storage.Save("students.xml", doc);
    }
}
