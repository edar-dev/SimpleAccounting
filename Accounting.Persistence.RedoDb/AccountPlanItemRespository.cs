using System;
using System.Collections.Generic;
using System.Linq;
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

        public AccountPlanItem GetById(Guid accountPlanId)
        {
            return _accountPlanItems.First(accountPlanItem => accountPlanItem.Id == accountPlanId);
        }

        public bool Exists(Guid accountPlanId)
        {
            return _accountPlanItems.Any(accountPlanItem => accountPlanItem.Id == accountPlanId);
        }

        public void SetRedoableGuid(IRedoableGuid redoableGuid)
        {
            _redoableGuid = redoableGuid;
        }
    }
}