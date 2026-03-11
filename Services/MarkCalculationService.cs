using SchoolManagement.Web.Models.Domain;

namespace SchoolManagement.Web.Services;

public interface IMarkCalculationService
{
    StudentMark Recalculate(StudentMark mark);
    (decimal total, decimal percentage, string result) BuildYearResult(IEnumerable<StudentMark> s1, IEnumerable<StudentMark> s2);
}

public class MarkCalculationService : IMarkCalculationService
{
    public StudentMark Recalculate(StudentMark mark)
    {
        mark.Total = mark.Activities + mark.Oral + mark.Homework + mark.Exam;
        mark.GradeText = mark.Total switch
        {
            >= 90 => "ممتاز",
            >= 80 => "جيد جداً",
            >= 70 => "جيد",
            >= 60 => "مقبول",
            _ => "ضعيف"
        };
        return mark;
    }

    public (decimal total, decimal percentage, string result) BuildYearResult(IEnumerable<StudentMark> s1, IEnumerable<StudentMark> s2)
    {
        var total = s1.Sum(x => x.Total) + s2.Sum(x => x.Total);
        var max = (s1.Count() + s2.Count()) * 100m;
        var percentage = max == 0 ? 0 : Math.Round(total / max * 100m, 2);
        var result = percentage >= 50 ? "ناجح" : "راسب";
        return (total, percentage, result);
    }
}
