using SchoolV001.Models.Domain;

namespace SchoolV001.Services;

public class MarkCalculationService : IMarkCalculationService
{
    public StudentMark Calculate(StudentMark mark)
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

    public (decimal total, decimal percentage, string result) FinalizeResult(IEnumerable<StudentMark> semesterOne, IEnumerable<StudentMark> semesterTwo)
    {
        var joined = semesterOne.Concat(semesterTwo).ToList();
        if (joined.Count == 0) return (0, 0, "قيد الدراسة");

        var total = joined.Sum(x => x.Total);
        var max = joined.Count * 200m;
        var percentage = max == 0 ? 0 : decimal.Round((total / max) * 100, 2);
        var result = percentage >= 50 ? "ناجح" : "راسب";
        return (total, percentage, result);
    }
}
