using Microsoft.EntityFrameworkCore;
using MyMVC.ADbContext;
using MyMVC.Models.Entity;

namespace MyMVC.Models.BusinessLogic
{
    public class StudentBL
    {
        SchoolDBContext Context = new SchoolDBContext();

        // تعديل: عملنا Include للقسم عشان نقدر نعرض اسم القسم في صفحة عرض كل الطلاب
        public List<Students> Index()
        {
            return Context.Students
                .Include(d => d.department)
                .ToList();
        }

        // تعديل: تحديد نوع الإرجاع Students? عشان يقبل null لو الطالب مش موجود
        public Students? GetbyId(int id)
        {
            return Context.Students
                .Include(d => d.department)
                .FirstOrDefault(s => s.Id == id);
        }

        public void add(Students stu)
        {
            Context.Students.Add(stu);
            Context.SaveChanges();
        }

        // تعديل: دالة حفظ التغييرات على قاعدة البيانات بعد تعديل بيانات الطالب
        public void savedb()
        {
            Context.SaveChanges();
        }

        // تعديل: دالة حذف الطالب مع حذف نتائجه المرتبطة أولاً لتجنب خطأ قيود المفتاح الأجنبي (Foreign Key)
        public void Delete(Students s)
        {
            var relatedResults = Context.StuCrsRes.Where(scr => scr.StudentId == s.Id);
            if (relatedResults.Any())
            {
                Context.StuCrsRes.RemoveRange(relatedResults);
            }

            Context.Students.Remove(s);
            Context.SaveChanges();
        }

        // تعديل: إتاحة حذف الطالب عبر الـ Id مباشرة لسهولة الاستخدام
        public void Delete(int id)
        {
            var student = Context.Students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                Delete(student);
            }
        }
    }
}

