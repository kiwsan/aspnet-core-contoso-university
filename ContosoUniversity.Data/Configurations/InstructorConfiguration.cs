using ContosoUniversity.Domain.Entities;
using ContosoUniversity.Data.Abstracts;
using ContosoUniversity.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Data.Configurations
{
    public class InstructorConfiguration : BaseConfiguration<Instructor>, IEntityConfiguration
    {
        public InstructorConfiguration(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public override void Configure()
        {
            base.Configure();

            _builder.Property(x => x.HireAtDate)
                .IsRequired();
            //_builder.Property(x => x.OfficeAssignmentId)
            //    .IsRequired();

            //_builder.HasOne(e => e.TableOfficeAssignment)
            //    .WithOne(c => c.TableInstructor);
        }
    }
}