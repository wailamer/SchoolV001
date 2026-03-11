using SchoolV001.Models.Domain;

namespace SchoolV001.Services;

public interface IPromotionService
{
    StudentRecord Promote(StudentRecord currentRecord);
}
