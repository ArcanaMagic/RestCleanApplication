using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RestCleanApplication.Domain.Base;
using RestCleanApplication.Domain.Book.Models;

namespace RestCleanApplication.Domain.Book.QueriesCommands
{
    public class GetAllBooksQuery : Query<PagedRequest, GetAllBooksResponse>
    {
        public GetAllBooksQuery(PagedRequest request) : base(request)
        {
        }
    }

    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, GetAllBooksResponse>
    {
        public Task<GetAllBooksResponse> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
