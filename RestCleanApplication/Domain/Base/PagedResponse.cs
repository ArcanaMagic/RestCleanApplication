namespace RestCleanApplication.Domain.Base
{
    public abstract class PagedResponse<TResponse> : IKeyFieldsResponse
    {
        public PageInfo<TResponse> Response { get; set; }
    }
}