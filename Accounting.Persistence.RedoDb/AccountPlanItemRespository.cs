using System.Collections.Generic;
using Accounting.Persistence.Entity;
using BoCode.RedoDB.RedoableData;

namespace Accounting.Persistence.RedoDb
{
    public class AccountPlanItemRespository : IAccountPlanItemRepository, IDependsOnRedoableGuid
    {
        private readonly ICollection<AccountPlanItem> _accountPlanItems = new List<AccountPlanItem>();
        private IRedoableGuid _redoableGuid;

        public AccountPlanItem Create(AccountPlanItem accountPlanItem)
        {
            accountPlanItem.Id = _redoableGuid.New();
            
            _accountPlanItems.Add(accountPlanItem);

            return accountPlanItem;
        }

        public void SetRedoableGuid(IRedoableGuid redoableGuid)
        {
            _redoableGuid = redoableGuid;
        }
    }
}