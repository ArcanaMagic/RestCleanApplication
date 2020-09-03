using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TestWebApplication.Domain.Base;
using TestWebApplication.Domain.Book.Models;

namespace TestWebApplication.Domain.Book.QueriesCommands
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
