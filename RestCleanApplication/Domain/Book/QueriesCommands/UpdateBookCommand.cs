using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RestCleanApplication.Domain.Base;
using RestCleanApplication.Domain.Book.Models;

namespace RestCleanApplication.Domain.Book.QueriesCommands
{
    public class UpdateBookCommand : Command<BookFieldsRequest, EmptyResponse>
    {
        public UpdateBookCommand(BookFieldsRequest request, Guid correlationId, string modifiedBy, Guid? id = null) : base(request, correlationId, modifiedBy, id)
        {
        }
    }

    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, EmptyResponse>
    {
        public Task<EmptyResponse> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
