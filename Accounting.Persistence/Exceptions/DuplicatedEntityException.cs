using System;

namespace Accounting.Persistence.Exceptions
{
    public class DuplicatedEntityException : Exception
    {
        public DuplicatedEntityException(string entityTypeName, Guid entityId, Exception exception) : base(
            $"Entity of type: {entityTypeName} with id: {entityId.ToString()} has multiple reference in the repository", exception)
        {
        }

    }
}