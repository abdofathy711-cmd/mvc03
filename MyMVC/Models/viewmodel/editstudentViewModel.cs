using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using MyMVC.Models.Entity;

namespace MyMVC.Models.viewmodel
{
    public class editstudentViewModel
    {
        // تعديل: الـ Id الأساسي للطالب المراد تعديله
        public int Id { get; set; }

        // تعديل: إضافة التحقق من إدخال الاسم وتحديد القيمة الافتراضية لتجنب تحذيرات الـ Nullable
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;

        // تعديل: إضافة التحقق من مدى العمر
        [Range(10, 100, ErrorMessage = "Age must be between 10 and 100")]
        public int? age { get; set; }

        // تعديل: تحديد رقم القسم كـ Nullable اختياري
        public int? DepartmentId { get; set; }

        // تعديل: إضافة [ValidateNever] لمنع التحقق من صحة القائمة أثناء الـ Post، عشان الفورم مش بيبعتها وبالتالي ModelState.IsValid ميبقاش false
        [ValidateNever]
        public List<Departments> department { get; set; } = new();
    }
}

