using ContosoUniversity.Domain.Enums;
using ContosoUniversity.Data.Context;
using Microsoft.Extensions.DependencyInjection;

namespace ContosoUniversity.Data.Interfaces
{
    public interface IDataProvider
    {
        DataProvider Provider { get; }
        IServiceCollection RegisterDbContext(IServiceCollection services, string connectionString);
        DataContext CreateDbContext(string connectionString);
    }
}