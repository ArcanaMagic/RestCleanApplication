using TestWebApplication.Domain.Base;

namespace TestWebApplication.Domain.Book.Models
{
    public class BookFieldsRequest : IFieldsRequest
    {
        public string Name { get; set; }
        public string Author { get; set; }
    }
}
