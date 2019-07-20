using ContosoUniversity.Domain.Entities;
using ContosoUniversity.Data.Abstracts;
using ContosoUniversity.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Data.Configurations
{
    public class CourseAssignmentConfiguration : BaseConfiguration<CourseAssignment>, IEntityConfiguration
    {
        public CourseAssignmentConfiguration(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public override void Configure()
        {
            base.Configure();

            _builder.Property(x => x.InstructorId)
                .IsRequired();
            _builder.Property(x => x.CourseId)
                .IsRequired();

            _builder.HasOne(e => e.TableCourse)
                .WithMany(c => c.TableCourseAssignments)
                .HasForeignKey(x => x.CourseId);
            _builder.HasOne(e => e.TableInstructor)
                .WithMany(c => c.TableCourseAssignments)
                .HasForeignKey(x => x.InstructorId);
        }
    }
}