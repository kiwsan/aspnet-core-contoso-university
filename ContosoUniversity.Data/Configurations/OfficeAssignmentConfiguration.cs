using ContosoUniversity.Domain.Entities;
using ContosoUniversity.Data.Abstracts;
using ContosoUniversity.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Data.Configurations
{
    public class OfficeAssignmentConfiguration : BaseConfiguration<OfficeAssignment>, IEntityConfiguration
    {
        public OfficeAssignmentConfiguration(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public override void Configure()
        {
            base.Configure();

            _builder.Property(x => x.Location)
                .IsRequired();
            //_builder.Property(x => x.InstructorId)
            //    .IsRequired();

            //_builder.HasOne(e => e.TableInstructor)
            //    .WithOne(c => c.TableOfficeAssignment);
        }
    }
}