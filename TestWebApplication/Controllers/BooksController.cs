using CorrelationId;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestWebApplication.Controllers.Base;
using TestWebApplication.Domain.Book.Models;


namespace TestWebApplication.Controllers
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