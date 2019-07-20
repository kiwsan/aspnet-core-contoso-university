using System;
using System.Linq;
using System.Reflection;
using ContosoUniversity.Domain.Entities;
using ContosoUniversity.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions contextOptions) : base(contextOptions)
        {
        }

        public DbSet<Course> TableCourses { get; set; }
        public DbSet<Enrollment> TableEnrollments { get; set; }
        public DbSet<Student> TableStudents { get; set; }
        public DbSet<Department> TableDepartments { get; set; }
        public DbSet<Instructor> TableInstructors { get; set; }
        public DbSet<OfficeAssignment> TableOfficeAssignments { get; set; }
        public DbSet<CourseAssignment> TableCourseAssignments { get; set; }
        public DbSet<Person> TablePeople { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            GetType().Assembly.GetTypes()
                .Where(t => !t.GetTypeInfo().IsAbstract && t.GetInterfaces().Contains(typeof(IEntityConfiguration)))
                .ToList()
                .ForEach(t => ((IEntityConfiguration) Activator.CreateInstance(t, new[] {modelBuilder})).Configure());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}