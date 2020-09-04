using System;
using MediatR;

namespace RestCleanApplication.Domain.Base
{
    public class Query<TRequest, TResponse> : IRequest<TResponse> 
        where TRequest : IViewModel
        where TResponse : IViewModel
    {
        public Guid? Id;
        public TRequest Request;
        public Query(TRequest request, Guid? id = null)
        {
            Id = id;
            Request = request;
        }

    }
}
