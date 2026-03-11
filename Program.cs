using SchoolV001.Repositories;
using SchoolV001.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<XmlStorageHelper>();
builder.Services.AddSingleton<SequenceService>();
builder.Services.AddSingleton<StudentRepository>();
builder.Services.AddSingleton<StudentRecordRepository>();
builder.Services.AddSingleton<SubjectRepository>();
builder.Services.AddSingleton<MarkRepository>();
builder.Services.AddSingleton<SchoolSettingsRepository>();
builder.Services.AddSingleton<DashboardService>();
builder.Services.AddSingleton<MarkCalculationService>();
builder.Services.AddSingleton<PromotionService>();

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
