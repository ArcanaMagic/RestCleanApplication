# RestCleanApplication

Данный проект демонстрирует новый подход к стандартизации Restful Api используя методологию CQRS и паттерн Mediatr, для net core. Ключевой момент это контроллер RestController, позволяющий быстро создавать новые конроллеры для новых моделей данных используя rest подход

Суть подхода в унифицировании реквестов и респонзов к каждому экшену контроллера по следующей логике Rest:

    IEmptyRequest       => [GET /books - Retrieves a list of books]            => IKeyResponse, IFieldsResponse
    IEmptyRequest + id  => [GET /books/12 - Retrieves a specific book id = 12] => IKeyResponse, IFieldsResponse
    IFieldsRequest      => [POST /books - Creates a new book]                  => IEmptyResponse
    IFieldsRequest + id => [PUT /books/12 - Updates book id = 12]              => IEmptyResponse
    IEmptyRequest + id  => [DELETE /books/12 - Deletes book id = 12]           => IEmptyResponse
    
где

    /// <summary>
    /// Интерфейс для модели данных без параметров
    /// </summary>
    public interface IEmptyRequest : IViewModel
    {
    }
    
    /// <summary>
    /// Интерфейс для модели данных содержащей только Id
    /// </summary>
    public interface IKeyRequest : IViewModel
    {
        Guid Id { get; set; }
    }
    
    /// <summary>
    /// Интерфейс для модели данных содержащей только основные поля, без Id и меты
    /// </summary>
    public interface IFieldsRequest : IViewModel
    {
    }
    
    
