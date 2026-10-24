using Microsoft.AspNetCore.Mvc;
using MyMVC.Models.BusinessLogic;
using MyMVC.Models.Entity;
using MyMVC.Models.viewmodel;

namespace MyMVC.Controllers
{
    public class StudentController : Controller
    {
        StudentBL sbl = new StudentBL();
        DepartmentBL dbl = new DepartmentBL();

        // /Student/DetailbyID
        public IActionResult DetailbyID(int id)
        {
            Students? s = sbl.GetbyId(id);
            return View("DetailbyID", s);
        }

        // /Student/allDetails
        public IActionResult alldetails()
        {
            List<Students> students = sbl.Index();
            return View("alldetails", students);
        }

        // /Student/add
        public IActionResult add()
        {
            return View("Add");
        }

        public IActionResult SaveAdd(Students s)
        {
            if (s.Name != null & s.DepartmentId != null)
            {
                sbl.add(s);
                return RedirectToAction(nameof(alldetails));
            }
            return View("Add", s);
        }

        // /Student/Edit/5
        // تعديل: أكشن الـ GET لعرض صفحة التعديل مع تعبئة بيانات الطالب والأقسام
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // تعديل: جلب بيانات الطالب والتأكد من وجوده لتفادي الأخطاء
            Students? s = sbl.GetbyId(id);
            if (s == null) return NotFound();

            // تعديل: إنشاء ViewModel وتمرير بيانات الطالب مع قائمة الأقسام لاختيار القسم منها
            var newstudent = new editstudentViewModel
            {
                Id = s.Id,
                Name = s.Name,
                age = s.age,
                DepartmentId = s.DepartmentId,
                department = dbl.GetAllDepartments() // تعديل: جلب الأقسام لتعبئة الـ DropDownList
            };

            return View("Edit", newstudent);
        }

        // تعديل: أكشن الـ POST لاستقبال البيانات المعدلة وحفظها
        [HttpPost]
        public IActionResult EditSave(editstudentViewModel es)
        {
            // تعديل: التحقق من صحة البيانات المُدخلة
            if (!ModelState.IsValid)
            {
                // تعديل: إعادة تعبئة قائمة الأقسام في حالة وجود أخطاء validation لمنع NullReferenceException في الفيو
                es.department = dbl.GetAllDepartments();
                return View("Edit", es);
            }

            // تعديل: جلب الطالب الحالي من قاعدة البيانات للتعديل عليه
            Students? oldstu = sbl.GetbyId(es.Id);
            if (oldstu == null) return NotFound();

            // تعديل: تعيين القيم الجديدة من الـ ViewModel للكائن الأصلي
            oldstu.Name = es.Name;
            oldstu.age = es.age;
            oldstu.DepartmentId = es.DepartmentId;

            // تعديل: استدعاء دالة الحفظ لتطبيق التغييرات في قاعدة البيانات
            sbl.savedb();

            // تعديل: استخدام RedirectToAction بدلاً من Redirect("allDetails") لضمان التوجيه الصحيح بالـ Route
            return RedirectToAction(nameof(alldetails));
        }

        // /Student/Delete/5
        // تعديل: أكشن الـ GET لعرض صفحة تأكيد حذف الطالب مع بياناته
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Students? s = sbl.GetbyId(id);
            if (s == null) return NotFound();

            // تعديل: تمرير الطالب لفيو الحذف
            return View("Delete", s);
        }

        // POST: /Student/DeleteSave
        // تعديل: أكشن الـ POST لحذف الطالب نهائياً من قاعدة البيانات بعد التأكيد
        [HttpPost]
        public IActionResult DeleteSave(int id)
        {
            Students? s = sbl.GetbyId(id);
            if (s != null)
            {
                sbl.Delete(s); // تعديل: حذف الطالب عبر الـ BL
            }
            return RedirectToAction(nameof(alldetails));
        }

        // POST: /Student/Delete/5
        // تعديل: دعم مسار POST على نفس اسم الأكشن Delete
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            return DeleteSave(id);
        }
    }
}

