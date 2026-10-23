using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMVC.Models.Entity;

namespace MyMVC.ADbContext.Configuration
{
    internal class CourseConfiguration : IEntityTypeConfiguration<Courses>
    {
        public void Configure(EntityTypeBuilder<Courses> builder)
        {
            //course Configure 
            builder.HasKey(c => c.ID);
            builder.Property(c => c.Name)
                .IsRequired(true)
                .HasMaxLength(100);
            builder.Property(c => c.Degree).IsRequired(false);
            builder.Property(c => c.MiniDegree).IsRequired(false);
            builder.Property(c => c.DepartmentId).IsRequired(false);
            // Configure the relationships with StuCrsRes
            builder.HasMany(c => c.StuCrsRes)
                .WithOne(s => s.course)
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
