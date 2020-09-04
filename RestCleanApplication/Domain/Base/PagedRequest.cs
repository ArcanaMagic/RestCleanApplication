using System.ComponentModel;

namespace RestCleanApplication.Domain.Base
{
    public class PagedRequest : IEmptyRequest
    {
        [DefaultValue(1)]
        public int PageNumber { get; set; } = 1;

        [DefaultValue(100)]
        public int PageSize { get; set; } = 100;
    }
}
