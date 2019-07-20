using MediatR;

namespace ContosoUniversity.Application.Commands.Student.Delete
{
    public class DeleteStudentCommand : IRequest<int>
    {
    }
}