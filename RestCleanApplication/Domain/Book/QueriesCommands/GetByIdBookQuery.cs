using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RestCleanApplication.Domain.Base;
using RestCleanApplication.Domain.Book.Models;

namespace RestCleanApplication.Domain.Book.QueriesCommands
{
    public class GetByIdBookQuery : Query<EmptyRequest, GetByIdBookResponse>
    {
        public GetByIdBookQuery(EmptyRequest request, Guid? id = null) : base(request, id)
        {
        }
    }

    public class GetByIdBookQueryHandler : IRequestHandler<GetByIdBookQuery, GetByIdBookResponse>
    {
        public Task<GetByIdBookResponse> Handle(GetByIdBookQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
