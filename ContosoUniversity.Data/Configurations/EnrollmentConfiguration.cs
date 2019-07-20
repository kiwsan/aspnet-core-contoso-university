using ContosoUniversity.Domain.Entities;
using ContosoUniversity.Data.Abstracts;
using ContosoUniversity.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Data.Configurations
{
    public class EnrollmentConfiguration : BaseConfiguration<Enrollment>, IEntityConfiguration
    {
        public EnrollmentConfiguration(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public override void Configure()
        {
            base.Configure();

            _builder.Property(x => x.Grade)
                .IsRequired();
            _builder.Property(x => x.CourseId)
                .IsRequired();
            _builder.Property(x => x.StudentId)
                .IsRequired();

            _builder.HasOne(e => e.TableCourse)
                .WithMany(c => c.TableEnrollments)
                .HasForeignKey(x => x.CourseId);
            _builder.HasOne(e => e.TableStudent)
                .WithMany(c => c.TableEnrollments)
                .HasForeignKey(x => x.StudentId);
        }
    }
}