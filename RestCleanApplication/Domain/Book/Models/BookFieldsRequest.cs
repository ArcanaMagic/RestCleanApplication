using RestCleanApplication.Domain.Base;

namespace RestCleanApplication.Domain.Book.Models
{
    public class BookFieldsRequest : IFieldsRequest
    {
        public string Name { get; set; }
        public string Author { get; set; }
    }
}
