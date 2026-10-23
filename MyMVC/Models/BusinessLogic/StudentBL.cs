using Microsoft.EntityFrameworkCore;
using MyMVC.ADbContext;
using MyMVC.Models.Entity;

namespace MyMVC.Models.BusinessLogic
{
    public class StudentBL
    {
        SchoolDBContext Context = new SchoolDBContext();
        public List<Students> Index()
        {
            return Context.Students.ToList();
        }
        public Students GetbyId(int id)
        {
            return Context.Students
                .Include(s => s.department)
                .FirstOrDefault(s => s.Id == id);

        }
    }
}
