using System;

namespace TestWebApplication.Domain.Base
{
    /// <summary>
    /// Интерфейс для модели данных содержащей только Id
    /// </summary>
    public interface IKeyRequest : IViewModel
    {
        Guid Id { get; set; }
    }
}
