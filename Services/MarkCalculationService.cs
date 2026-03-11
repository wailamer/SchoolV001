using SchoolV001.Models.Domain;

namespace SchoolV001.Services;

public class MarkCalculationService
{
    public StudentMark Calculate(StudentMark mark)
    {
        mark.Total = mark.Activities + mark.Oral + mark.Homework + mark.Exam;
        mark.GradeText = mark.Total switch
        {
            >= 90 => "ممتاز",
            >= 80 => "جيد جدًا",
            >= 70 => "جيد",
            >= 60 => "مقبول",
            _ => "ضعيف"
        };

        return mark;
    }
}
