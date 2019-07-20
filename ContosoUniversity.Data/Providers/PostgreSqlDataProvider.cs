using ContosoUniversity.Domain.Enums;
using ContosoUniversity.Data.Context;
using ContosoUniversity.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ContosoUniversity.Data.Providers
{
    public class PostgreSqlDataProvider : IDataProvider
    {
        public DataProvider Provider { get; } = DataProvider.PostgreSql;

        public IServiceCollection RegisterDbContext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseNpgsql(connectionString));

            return services;
        }

        public DataContext CreateDbContext(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new DataContext(optionsBuilder.Options);
        }
    }
}