using System;
using Accounting.Persistence.Entity;

namespace Accounting.Persistence
{
    public interface IAccountPlanItemRepository
    {
        AccountPlanItem Create(AccountPlanItem company);

        AccountPlanItem GetById(Guid accountPlanId);
        
        bool Exists(Guid accountPlanId);
    }
}