using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using MyMVC.Models.Entity;
namespace MyMVC.ADbContext
{
    internal class SchoolDBContext : DbContext
    {
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<StuCrsRes> StuCrsRes { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=nschool;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
        }
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Configuration.DepartmentConFiguration());
            modelBuilder.ApplyConfiguration(new Configuration.StudentConfiguration());
            modelBuilder.ApplyConfiguration(new Configuration.CourseConfiguration());
            modelBuilder.ApplyConfiguration(new Configuration.STtuCrsResConfiguration());
            modelBuilder.ApplyConfiguration(new Configuration.TeacherConfiguration());
        }

    }
}
