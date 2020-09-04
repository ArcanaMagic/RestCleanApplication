using System.Collections.Generic;

namespace RestCleanApplication.Domain.Base
{
    public abstract class PageInfo<TResponse>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalElements { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public List<TResponse> Results { get; set; }
    }
}
