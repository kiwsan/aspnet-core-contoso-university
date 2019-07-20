using FluentValidation;

namespace ContosoUniversity.Application.Commands.Student.Create
{
    public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentCommandValidator()
        {
        }
    }
}