namespace SchoolV001.Models.Domain;

public class StudentRegistration
{
    public int Id { get; set; }
    public string GeneralRegisterNumber { get; set; } = string.Empty;
    public string MinistryCode { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string FatherName { get; set; } = string.Empty;
    public string GrandFatherName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string MotherName { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public string BirthPlace { get; set; } = string.Empty;
    public string Gender { get; set; } = "أنثى";
    public string Religion { get; set; } = string.Empty;
    public string CivilRegistryPlace { get; set; } = string.Empty;
    public string CivilRegistryNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string PhotoPath { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; } = true;
    public string FullName => $"{FirstName} {FatherName} {GrandFatherName} {LastName}".Trim();
}
