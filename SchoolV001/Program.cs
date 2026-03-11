using SchoolV001.Repositories;
using SchoolV001.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<XmlStorageHelper>();
builder.Services.AddSingleton<SequenceService>();
builder.Services.AddScoped<StudentRepository>();
builder.Services.AddScoped<StudentRecordRepository>();
builder.Services.AddScoped<SubjectRepository>();
builder.Services.AddScoped<TeacherRepository>();
builder.Services.AddScoped<AttendanceRepository>();
builder.Services.AddScoped<MarkRepository>();
builder.Services.AddScoped<SchoolSettingsRepository>();
builder.Services.AddScoped<DashboardRepository>();
builder.Services.AddScoped<PromotionService>();
builder.Services.AddScoped<MarkCalculationService>();

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
