using CorrelationId;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestCleanApplication.Controllers.Base;
using RestCleanApplication.Domain.Book.Models;

namespace RestCleanApplication.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class BooksController : RestController<BookFieldsRequest, BookKeyFieldsResponse>
    {
        public BooksController(IMediator mediator, ICorrelationContextAccessor correlationContext) : base(mediator, correlationContext)
        {
        }
    }
}