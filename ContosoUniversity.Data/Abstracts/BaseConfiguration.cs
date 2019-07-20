using ContosoUniversity.Domain.Abstracts;
using ContosoUniversity.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContosoUniversity.Data.Abstracts
{
    public abstract class BaseConfiguration<T> : IEntityConfiguration where T : BaseEntity
    {
        protected readonly ModelBuilder _modelBuilder;
        protected EntityTypeBuilder<T> _builder => _modelBuilder.Entity<T>();

        protected BaseConfiguration(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public virtual void Configure()
        {
            _builder.Property(p => p.Id).ValueGeneratedOnAdd();
            _builder.Property(e => e.Timestamp).ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
        }
    }
}