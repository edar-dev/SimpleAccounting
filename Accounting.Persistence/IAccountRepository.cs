using System;
using Accounting.Persistence.Entity;

namespace Accounting.Persistence
{
    public interface IAccountRepository
    {
        Guid SaveChartOfAccount(ChartOfAccounts coa);
        ChartOfAccounts GetChartOfAccount(Guid chartOfAccountId);
    }
}