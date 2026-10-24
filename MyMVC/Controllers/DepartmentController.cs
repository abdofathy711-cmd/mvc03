using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyMVC.Models.BusinessLogic;
using MyMVC.Models.Entity;
using MyMVC.Models.viewmodel;
namespace MyMVC.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentBL depbl = new DepartmentBL();

        // /Department/showall
        public IActionResult showall()
        {

            List<Departments> deps = depbl.GetAllDepartments();

            return View("showall", deps);
        }

        // /Department/showbyid
        public IActionResult showbyid(int id)
        {
            Departments dept = depbl.GetDepartmentById(id);
            if (dept == null) return NotFound();

            int count = dept.students.Count;

            var vm = new Departmentviewmodel
            {
                depID = dept.Id,
                DepName = dept.Name,
                ManName = dept.MgrName ?? "No manager assigned",
                DepState = count > 50 ? "Main" : "Branch",

                students = dept.students
                    .Where(s => s.age > 25)
                    .Select(s => new SelectListItem
                    {
                        Value = s.Id.ToString(),     // كان ناقص اسم الـ Property
                        Text = s.Name
                    })
                    .ToList()                        // كان ناقص
            };

            return View("showbyid", vm);
        }
        // /Department/add

        public IActionResult add()
        {
            return View("add");
        }
    
        public IActionResult saveadd(Departments dep)
        {
            if (dep.Name != null)
            {
               
                depbl.add(dep);
                
                return RedirectToAction(nameof(showall));
            }
            return View("add", dep); 


        }

     


    }
}
