using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMVC.Models.Entity;

namespace MyMVC.ADbContext.Configuration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Departments>
    {
        public void Configure(EntityTypeBuilder<Departments> builder)
        {
            //dep configuration
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Name)
                .IsRequired(true)
                .HasMaxLength(100);
            builder.Property(d => d.MgrName)
                .IsRequired(true)
                .HasMaxLength(100);
            // Configure the relationships with Teachers
            builder.HasMany(d => d.teachers)
                .WithOne(t => t.department)
                .HasForeignKey(t => t.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
            // Configure the relationships with students
            builder.HasMany(d => d.students)
                .WithOne(s => s.department)
                .HasForeignKey(s => s.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
            // Configure the relationships with courses
            builder.HasMany(d => d.Courses)
                .WithOne(c => c.department)
                .HasForeignKey(c => c.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
