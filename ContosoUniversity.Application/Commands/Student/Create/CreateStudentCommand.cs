using MediatR;

namespace ContosoUniversity.Application.Commands.Student.Create
{
    public class CreateStudentCommand : IRequest<int>
    {
    }
}