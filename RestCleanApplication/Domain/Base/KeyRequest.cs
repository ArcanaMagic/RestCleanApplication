using System;

namespace RestCleanApplication.Domain.Base
{
    public class KeyRequest : IKeyRequest
    {
        public Guid Id { get; set; }
    }
}
