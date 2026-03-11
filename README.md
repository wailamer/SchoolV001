# نظام إدارة مدرسة - ASP.NET Core MVC + XML

هذا المشروع هو نسخة تأسيسية احترافية لنظام إدارة مدرسة متكامل وفق التحليل الذي طلبته، مبني على:

- ASP.NET Core MVC (هيكل قابل للتوسع)
- XML Storage (مرحلة أولى قبل SQL Server)
- واجهة عربية RTL
- فصل واضح بين: التسجيل الأساسي، السجل السنوي، العمليات الأكاديمية

## الطبقات المنفذة

- **Controllers**: Dashboard, Students, Attendance, Marks, Reports, Settings, Teachers, Subjects, Classes, Import.
- **Domain Models**: StudentRegistration, StudentRecord, Teacher, Subject, AttendanceEntry, StudentMark, SchoolSettings, SequenceState.
- **Repositories**: للوصول إلى XML لكل وحدة بيانات.
- **Services**:
  - `XmlStorageHelper`: قراءة/كتابة XML مع حماية من التلف.
  - `SequenceService`: توليد أرقام تسلسلية غير مكررة.
  - `MarkCalculationService`: حساب المجموع والتقدير والنتيجة النهائية.
  - `PromotionService`: إنشاء سجل سنوي جديد للترفيع دون المساس بالأرشيف.
  - `ReportRenderingService`: تجهيز نموذج الجلاء للحلقة الأولى.

## بنية XML الحالية

- `Data/Xml/students.xml`
- `Data/Xml/student-records.xml`
- `Data/Xml/subjects.xml`
- `Data/Xml/teachers.xml`
- `Data/Xml/attendance.xml`
- `Data/Xml/marks.xml`
- `Data/Xml/school-settings.xml`
- `Data/Xml/sequences.xml`

## الملاحظات

- البيئة الحالية لا تحتوي على `dotnet` لذلك تعذر التشغيل/البناء داخل نفس البيئة.
- المشروع جاهز هيكليًا لبدء التطوير التفصيلي للشاشات، التحقق من المدخلات، الصلاحيات، والطباعة/PDF.

## الخطوة التالية المقترحة

1. تثبيت .NET SDK 8.0.
2. تشغيل:
   - `dotnet restore`
   - `dotnet build`
   - `dotnet run`
3. البدء بالمرحلة الوظيفية التفصيلية:
   - إدخال الغياب الجماعي
   - إدخال علامات فصل 1/2 حسب قوالب المراحل
   - توليد الجلاء المطابق للنموذج الرسمي مع PDF
