using ContosoUniversity.Domain.Entities;
using ContosoUniversity.Data.Abstracts;
using ContosoUniversity.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Data.Configurations
{
    public class CourseConfiguration : BaseConfiguration<Course>, IEntityConfiguration
    {
        public CourseConfiguration(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public override void Configure()
        {
            base.Configure();

            _builder.Property(x => x.Code)
                .IsRequired();
            _builder.Property(x => x.Credits)
                .IsRequired();
            _builder.Property(x => x.Title)
                .IsRequired();
            _builder.Property(x => x.DepartmentId)
                .IsRequired();

            _builder.HasOne(e => e.TableDepartment)
                .WithMany(c => c.TableCourses)
                .HasForeignKey(x => x.DepartmentId);;
        }
    }
}