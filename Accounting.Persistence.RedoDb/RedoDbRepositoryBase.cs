using System;
using BoCode.RedoDB.RedoableData;

namespace Accounting.Persistence.RedoDb
{
    public class RedoDbRepositoryBase
    {
        protected IRedoableGuid? _redoableGuid;

        public void SetRedoableGuid(IRedoableGuid redoableGuid)
        {
            _redoableGuid = redoableGuid;
        }

        public Guid GetReduableGuid()
        {
            return _redoableGuid?.New() ?? Guid.NewGuid();
        }
    }
}