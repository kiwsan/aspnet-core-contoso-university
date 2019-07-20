using System;
using System.Linq;
using System.Reflection;
using ContosoUniversity.Data.Interfaces;
using Microsoft.EntityFrameworkCore.Design;

namespace ContosoUniversity.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var provider = GetType().Assembly.GetTypes()
                .Where(t => !t.GetTypeInfo().IsAbstract && t.GetInterfaces().Contains(typeof(IDataProvider)))
                .SingleOrDefault(t => t.Name.Contains("PostgreSql"));
            
            return ((IDataProvider)Activator.CreateInstance(provider)).CreateDbContext("User ID=postgres;Password=Str0ngPassword!;Host=localhost;Port=5432;Database=contoso_university;Pooling=true;");
        }
    }
}