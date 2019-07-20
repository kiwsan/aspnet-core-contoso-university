using System;
using System.Threading;
using System.Threading.Tasks;
using ContosoUniversity.Application.Commands.Student.Create;
using ContosoUniversity.Application.Commands.Student.Delete;
using ContosoUniversity.Application.Commands.Student.Update;
using ContosoUniversity.Application.Events.Student.Created;
using ContosoUniversity.Application.Events.Student.Deleted;
using ContosoUniversity.Application.Events.Student.Updated;
using ContosoUniversity.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Application.Commands.Student
{
    public class StudentCommandHandlersAsync : BaseCommandHandlersAsync,
        IRequestHandler<CreateStudentCommand, int>,
        IRequestHandler<UpdateStudentCommand, int>,
        IRequestHandler<DeleteStudentCommand, int>
    {
        public StudentCommandHandlersAsync(DataContext context, IMediator mediator) : base(context, mediator)
        {
        }

        public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _context.TableStudents.FirstOrDefaultAsync(cancellationToken);

            if (await CommitAsync(cancellationToken))
            {
                await _mediator.Publish(new StudentCreatedEvent("Worker", "Johnnie", DateTime.Now),
                    cancellationToken);
            }

            throw new NotImplementedException();
        }

        public async Task<int> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _context.TableStudents.FirstOrDefaultAsync(cancellationToken);

            if (await CommitAsync(cancellationToken))
            {
                await _mediator.Publish(new StudentUpdatedEvent("Worker", "Johnnie", DateTime.Now),
                    cancellationToken);
            }

            throw new NotImplementedException();
        }

        public async Task<int> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _context.TableStudents.FirstOrDefaultAsync(cancellationToken);

            if (await CommitAsync(cancellationToken))
            {
                await _mediator.Publish(new StudentDeletedEvent("Worker", "Johnnie", DateTime.Now),
                    cancellationToken);
            }

            throw new NotImplementedException();
        }
    }
}