using System.Collections.Generic;

namespace Accounting.Persistence.Entity
{
    public class Account : EntityBase
    {
        public Account(string name, int number, AccountType accountType,
            IEnumerable<Account> childrenAccounts)
        {
            Name = name;
            Number = number;
            AccountType = accountType;
            ChildrenAccounts = childrenAccounts;
        }

        public string Name { get; }

        public int Number { get; }

        public AccountType AccountType { get; }
        public IEnumerable<Account> ChildrenAccounts { get; }
    }
}