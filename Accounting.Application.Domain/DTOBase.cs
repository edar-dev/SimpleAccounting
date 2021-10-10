using System;

namespace Accounting.Application.Domain
{
    public class DtoBase
    {
        public Guid Id { get; set; } = Guid.Empty;
    }
}