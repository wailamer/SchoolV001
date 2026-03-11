using System.Xml.Linq;
using SchoolV001.Models.Domain;
using SchoolV001.Services;

namespace SchoolV001.Repositories;

public class StudentRepository
{
    private const string FileName = "students.xml";
    private readonly XmlStorageHelper _storage;

    public StudentRepository(XmlStorageHelper storage) => _storage = storage;

    public List<StudentRegistration> GetAll()
    {
        var doc = _storage.LoadOrCreate(FileName, "StudentRegistrations");
        return doc.Root?.Elements("Student").Select(Map).ToList() ?? [];
    }

    public StudentRegistration? GetById(int id) => GetAll().FirstOrDefault(x => x.Id == id);

    public bool MinistryCodeExists(string code) => GetAll().Any(x => x.MinistryCode == code);

    public void Add(StudentRegistration student)
    {
        var doc = _storage.LoadOrCreate(FileName, "StudentRegistrations");
        doc.Root?.Add(new XElement("Student",
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
            new XElement("Gender", student.Gender),
            new XElement("Religion", student.Religion),
            new XElement("CivilRegistryPlace", student.CivilRegistryPlace),
            new XElement("CivilRegistryNumber", student.CivilRegistryNumber),
            new XElement("Address", student.Address),
            new XElement("Phone", student.Phone),
            new XElement("PhotoPath", student.PhotoPath),
            new XElement("CreatedDate", student.CreatedDate.ToString("yyyy-MM-dd")),
            new XElement("IsActive", student.IsActive)));

        _storage.Save(FileName, doc);
    }

    private static StudentRegistration Map(XElement x) => new()
    {
        Id = (int?)x.Element("Id") ?? 0,
        GeneralRegisterNumber = (string?)x.Element("GeneralRegisterNumber") ?? string.Empty,
        MinistryCode = (string?)x.Element("MinistryCode") ?? string.Empty,
        FirstName = (string?)x.Element("FirstName") ?? string.Empty,
        FatherName = (string?)x.Element("FatherName") ?? string.Empty,
        GrandFatherName = (string?)x.Element("GrandFatherName") ?? string.Empty,
        LastName = (string?)x.Element("LastName") ?? string.Empty,
        MotherName = (string?)x.Element("MotherName") ?? string.Empty,
        BirthDate = DateTime.TryParse((string?)x.Element("BirthDate"), out var d) ? d : DateTime.UtcNow,
        BirthPlace = (string?)x.Element("BirthPlace") ?? string.Empty,
        Gender = (string?)x.Element("Gender") ?? string.Empty,
        Religion = (string?)x.Element("Religion") ?? string.Empty,
        CivilRegistryPlace = (string?)x.Element("CivilRegistryPlace") ?? string.Empty,
        CivilRegistryNumber = (string?)x.Element("CivilRegistryNumber") ?? string.Empty,
        Address = (string?)x.Element("Address") ?? string.Empty,
        Phone = (string?)x.Element("Phone") ?? string.Empty,
        PhotoPath = (string?)x.Element("PhotoPath") ?? string.Empty,
        IsActive = (bool?)x.Element("IsActive") ?? true
    };
}
