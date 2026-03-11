using SchoolV001.Repositories;
using SchoolV001.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IXmlStorageHelper, XmlStorageHelper>();
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

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();
