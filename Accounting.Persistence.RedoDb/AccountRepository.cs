using System;
using System.Collections.Generic;
using System.Linq;
using Accounting.Persistence.Entity;
using Accounting.Persistence.Exceptions;
using BoCode.RedoDB.RedoableData;

namespace Accounting.Persistence.RedoDb
{
    public class AccountRepository : RedoDbRepositoryBase, IAccountRepository, IDependsOnRedoableGuid
    {
        private readonly ICollection<ChartOfAccounts> _chartOfAccounts = new List<ChartOfAccounts>();

        public Guid SaveChartOfAccount(ChartOfAccounts coa)
        {
            coa.Id = GetReduableGuid();

            foreach (var account in coa.Accounts)
            {
                SetAccountIdentityRecursively(account);
            }
            _chartOfAccounts.Add(coa);

            return coa.Id;
        }

        public ChartOfAccounts GetChartOfAccount(Guid chartOfAccountId)
        {
            try
            {
                var coa =  _chartOfAccounts.SingleOrDefault(coa => coa.Id == chartOfAccountId);

                if (coa is null)
                {
                    throw new EntityNotFoundException(nameof(ChartOfAccounts),chartOfAccountId);    
                }

                return coa;
            }
            catch (InvalidOperationException e)
            {
                throw new DuplicatedEntityException(nameof(ChartOfAccounts),chartOfAccountId,e);
            }
        }

        private void SetAccountIdentityRecursively(Account account)
        {
            account.Id = GetReduableGuid();
            
            foreach (var childrenAccount in account.ChildrenAccounts)
            {
                SetAccountIdentityRecursively(childrenAccount);
            }
        }
    }
}