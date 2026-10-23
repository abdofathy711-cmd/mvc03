using Microsoft.AspNetCore.Mvc;
using MyMVC.Models.BusinessLogic;
using MyMVC.Models.Entity;

namespace MyMVC.Controllers
{
    public class StudentController : Controller
    {

        // /Student/DetailbyID
        public IActionResult DetailbyID(int id)
        {
            StudentBL sbl = new StudentBL();
            Students? s = sbl.GetbyId(id);

            return View("DetailbyID", s);
        }
        // /Student/allDetails
        public IActionResult alldetails()
        {
            StudentBL sbl = new StudentBL();
            List<Students> students = sbl.Index();
            return View("alldetails", students);
        }
    }
}
