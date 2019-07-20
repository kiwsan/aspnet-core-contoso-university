using System.Threading;
using System.Threading.Tasks;
using ContosoUniversity.Application.Events.Student.Created;
using ContosoUniversity.Application.Events.Student.Deleted;
using ContosoUniversity.Application.Events.Student.Updated;
using MediatR;

namespace ContosoUniversity.Application.Events.Student
{
    public class StudentEventHandlersAsync : INotificationHandler<StudentCreatedEvent>,
        INotificationHandler<StudentUpdatedEvent>,
        INotificationHandler<StudentDeletedEvent>
    {
        public Task Handle(StudentCreatedEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task Handle(StudentUpdatedEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task Handle(StudentDeletedEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}