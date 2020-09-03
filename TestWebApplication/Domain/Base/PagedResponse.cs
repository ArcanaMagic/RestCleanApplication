namespace TestWebApplication.Domain.Base
{
    public abstract class PagedResponse<TResponse> : IKeyFieldsResponse
    {
        public PageInfo<TResponse> Response { get; set; }
    }
}