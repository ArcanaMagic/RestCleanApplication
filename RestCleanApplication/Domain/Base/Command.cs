using System;
using MediatR;

namespace RestCleanApplication.Domain.Base
{
    public class Command<TRequest, TResponse> : IRequest<TResponse> 
        where TRequest : IViewModel
        where TResponse : IViewModel
    {
        public Guid? Id;
        public TRequest Request;
        public readonly Guid CorrelationId;
        public readonly string ModifiedBy;

        public Command(TRequest request, Guid correlationId, string modifiedBy, Guid? id = null)
        {
            Id = id;
            Request = request;
            CorrelationId = correlationId;
            ModifiedBy = modifiedBy;
        }

    }
}
