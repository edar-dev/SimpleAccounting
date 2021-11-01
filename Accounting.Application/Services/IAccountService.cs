using System;
using Accounting.Application.Domain.Account;

namespace Accounting.Application.Services
{
    public interface IAccountService
    {
        ChartOfAccountsDto GetChartOfAccounts(Guid chartOfAccountId);
        Guid CreateChartOfAccounts(ChartOfAccountsDto chartOfAccountsDto);
    }
}