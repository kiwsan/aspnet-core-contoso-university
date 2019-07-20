using ContosoUniversity.Domain.Entities;
using ContosoUniversity.Data.Abstracts;
using ContosoUniversity.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Data.Configurations
{
    public class DepartmentConfiguration : BaseConfiguration<Department>, IEntityConfiguration
    {
        public DepartmentConfiguration(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public override void Configure()
        {
            base.Configure();

            _builder.Property(x => x.Budget)
                .HasColumnType("money")
                .IsRequired();
            _builder.Property(x => x.Name)
                .IsRequired();
            _builder.Property(x => x.InstructorId)
                .IsRequired();

            _builder.HasOne(e => e.TableInstructor)
                .WithMany(c => c.TableDepartments)
                .HasForeignKey(x => x.InstructorId);
        }
    }
}