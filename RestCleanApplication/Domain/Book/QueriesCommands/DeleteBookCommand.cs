using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RestCleanApplication.Domain.Base;

namespace RestCleanApplication.Domain.Book.QueriesCommands
{
    public class DeleteBookCommand : Command<KeyRequest, EmptyResponse>
    {
        public DeleteBookCommand(KeyRequest request, Guid correlationId, string modifiedBy, Guid? id = null) : base(request, correlationId, modifiedBy, id)
        {
        }
    }

    public class DeleteCommandHandler : IRequestHandler<DeleteBookCommand, EmptyResponse>
    {
        public Task<EmptyResponse> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
