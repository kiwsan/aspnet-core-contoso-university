using System.Threading;
using System.Threading.Tasks;
using ContosoUniversity.Data.Context;
using MediatR;

namespace ContosoUniversity.Application.Commands
{
    public abstract class BaseCommandHandlersAsync
    {
        protected readonly DataContext _context;
        protected readonly IMediator _mediator;

        public BaseCommandHandlersAsync(DataContext context,
            IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        protected async Task<bool> CommitAsync(CancellationToken cancellationToken = default(CancellationToken))
            => await _context.SaveChangesAsync(cancellationToken) > 0;
    }
}