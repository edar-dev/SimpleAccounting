using System;
using System.Collections.Generic;
using System.Linq;
using Accounting.Persistence.Entity;
using BoCode.RedoDB.RedoableData;

namespace Accounting.Persistence.RedoDb
{
    public class AccountRepository : IAccountRepository, IDependsOnRedoableGuid
    {
        private ICollection<Account> _accounts = new List<Account>();
        private IRedoableGuid? _redoableGuid;

        public Account Create(Account account)
        {
            if (account.ParentAccountId.HasValue && !_accounts.Any(a => a.Id == account.ParentAccountId.Value))
            {
                throw new InvalidOperationException(
                    $"Impossible to create the account {account.Name} because the parent account {account.ParentAccountId.Value} does not exists");
            }
            
            account.Id = _redoableGuid?.New() ?? Guid.NewGuid();
            
            _accounts.Add(account);

            return account;
        }

        public Account Get(Guid accountId)
        {
            return _accounts.Single(a => a.Id == accountId);
        }

        public void SetRedoableGuid(IRedoableGuid redoableGuid)
        {
            _redoableGuid = redoableGuid;
        }
    }
}