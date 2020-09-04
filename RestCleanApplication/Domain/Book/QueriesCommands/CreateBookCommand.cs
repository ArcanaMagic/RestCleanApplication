using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RestCleanApplication.Domain.Base;
using RestCleanApplication.Domain.Book.Models;

namespace RestCleanApplication.Domain.Book.QueriesCommands
{
    public class CreateBookCommand : Command<BookFieldsRequest, EmptyResponse>
    {
        public CreateBookCommand(BookFieldsRequest request, Guid correlationId, string modifiedBy) : base(request, correlationId, modifiedBy)
        {
        }
    }

    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, EmptyResponse>
    {
        public Task<EmptyResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
