using SchoolManagement.Web.Repositories;
using SchoolManagement.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<XmlStorageHelper>();
builder.Services.AddSingleton<ISequenceService, SequenceService>();
builder.Services.AddSingleton<IStudentRepository, StudentRepository>();
builder.Services.AddSingleton<IStudentRecordRepository, StudentRecordRepository>();
builder.Services.AddSingleton<ITeacherRepository, TeacherRepository>();
builder.Services.AddSingleton<ISubjectRepository, SubjectRepository>();
builder.Services.AddSingleton<IAttendanceRepository, AttendanceRepository>();
builder.Services.AddSingleton<IMarkRepository, MarkRepository>();
builder.Services.AddSingleton<ISchoolSettingsRepository, SchoolSettingsRepository>();
builder.Services.AddSingleton<IMarkCalculationService, MarkCalculationService>();
builder.Services.AddSingleton<IPromotionService, PromotionService>();
builder.Services.AddSingleton<IReportRenderingService, ReportRenderingService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();
