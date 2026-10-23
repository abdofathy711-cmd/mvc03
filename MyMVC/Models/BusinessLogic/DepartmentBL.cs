using Microsoft.EntityFrameworkCore;
using MyMVC.ADbContext;
using MyMVC.Models.Entity;

namespace MyMVC.Models.BusinessLogic
{
    public class DepartmentBL
    {
        SchoolDBContext context=new SchoolDBContext();
        public List<Departments> GetAllDepartments()
        {
            return context.Departments.ToList();
        }
        public Departments GetDepartmentById(int id)
        {
            return context.Departments
                .Include(s=>s.students)
                .FirstOrDefault(d => d.Id == id);
        }
        public void add(Departments dep)
        {
            context.Departments.Add(dep);
            context.SaveChanges();
        }

    }
}
