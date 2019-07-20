using ContosoUniversity.Domain.Entities;
using ContosoUniversity.Data.Abstracts;
using ContosoUniversity.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Data.Configurations
{
    public class StudentConfiguration : BaseConfiguration<Student>, IEntityConfiguration
    {
        public StudentConfiguration(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public override void Configure()
        {
            base.Configure();

            _builder.Property(x => x.EnrollmentAtDate)
                .IsRequired();
        }
    }
}