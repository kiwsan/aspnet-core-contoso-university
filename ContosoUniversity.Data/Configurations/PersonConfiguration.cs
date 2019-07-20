using ContosoUniversity.Domain.Entities;
using ContosoUniversity.Data.Abstracts;
using ContosoUniversity.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Data.Configurations
{
    public class PersonConfiguration : BaseConfiguration<Person>, IEntityConfiguration
    {
        public PersonConfiguration(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public override void Configure()
        {
            base.Configure();

            _builder.Property(x => x.FirstName)
                .IsRequired();
            _builder.Property(x => x.LastName)
                .IsRequired();
        }
    }
}