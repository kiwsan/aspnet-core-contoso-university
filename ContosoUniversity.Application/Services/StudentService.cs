using ContosoUniversity.Application.Interfaces;
using ContosoUniversity.Data.Context;

namespace ContosoUniversity.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly DataContext _context;

        public StudentService(DataContext context)
        {
            _context = context;
        }
    }
}