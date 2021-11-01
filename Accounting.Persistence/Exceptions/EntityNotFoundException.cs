using System;

namespace Accounting.Persistence.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string entityTypeName, Guid entityId, Exception exception) : base(
            $"Entity of type: {entityTypeName} with id: {entityId.ToString()} not fund in the repository ", exception)
        {
        }

        public EntityNotFoundException(string entityTypeName, Guid entityId) : base(
            $"Entity of type: {entityTypeName} with id: {entityId.ToString()} not fund in the repository ")
        {
        }
    }
}