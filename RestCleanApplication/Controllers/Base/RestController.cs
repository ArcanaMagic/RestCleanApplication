using System;
using System.Threading.Tasks;
using CorrelationId;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestCleanApplication.Domain.Base;
using Swashbuckle.AspNetCore.Annotations;

namespace RestCleanApplication.Controllers.Base
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public abstract class RestController<TFieldsRequest, TKeyFieldsResponse> : ControllerBase
        where TFieldsRequest : IFieldsRequest
        where TKeyFieldsResponse : IKeyFieldsResponse
    {
        private readonly IMediator _mediator;
        private readonly ICorrelationContextAccessor _correlationContext;

        protected RestController(IMediator mediator, ICorrelationContextAccessor correlationContext)
        {
            _mediator = mediator;
            _correlationContext = correlationContext;
        }

        /// <summary>
        /// Request:  IEmptyRequest |
        /// Response: IKeyResponse, IFieldsResponse
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status404NotFound, Type = typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public virtual async Task<ActionResult<TKeyFieldsResponse>> GetAsync([FromQuery] PagedRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var query = new Query<PagedRequest, TKeyFieldsResponse>(request);
            var response = await _mediator.Send(query);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        /// <summary>
        /// Request:  IEmptyRequest (плюс Id передаваемый отдельным параметром) |
        /// Response: IKeyResponse, IFieldsResponse
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:Guid}")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status404NotFound, Type = typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public virtual async Task<ActionResult<TKeyFieldsResponse>> GetByIdAsync([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Id is not correct!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var query = new Query<EmptyRequest, TKeyFieldsResponse>(new EmptyRequest(), id);
            var response = await _mediator.Send(query);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        /// <summary>
        /// Request:  IFieldsRequest |
        /// Response: IEmptyResponse
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status201Created)]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public virtual async Task<IActionResult> CreateAsync([FromBody] TFieldsRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var correlationId = Guid.Parse(_correlationContext.CorrelationContext.CorrelationId);
            var modifiedBy = HttpContext.User.Identity.Name;

            var command = new Command<TFieldsRequest, EmptyResponse>(request, correlationId, modifiedBy);
            await _mediator.Send(command);

            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        /// Request:  IFieldsRequest (плюс Id передаваемый отдельным параметром) |
        /// Response: IEmptyResponse
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id:Guid}")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public virtual async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] TFieldsRequest request)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Id is not correct!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var correlationId = Guid.Parse(_correlationContext.CorrelationContext.CorrelationId);
            var modifiedBy = HttpContext.User.Identity.Name;

            var command = new Command<TFieldsRequest, EmptyResponse>(request, correlationId, modifiedBy, id);
            await _mediator.Send(command);

            return StatusCode(StatusCodes.Status204NoContent);
        }

        /// <summary>
        /// Request:  IEmptyRequest (плюс Id передаваемый отдельным параметром) |
        /// Response: IEmptyResponse
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:Guid}")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public virtual async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Id is not correct!");
            }

            var correlationId = Guid.Parse(_correlationContext.CorrelationContext.CorrelationId);
            var modifiedBy = HttpContext.User.Identity.Name;

            var command = new Command<EmptyRequest, EmptyResponse>(new EmptyRequest(), correlationId, modifiedBy, id);
            await _mediator.Send(command);

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
