#nullable enable
using System.Collections.Generic;

namespace Accounting.Application.Domain.Account
{
    public class AccountDto : DtoBase
    {
        public AccountDto(string name, int number, AccountType accountType,
            IEnumerable<AccountDto> childrenAccounts)
        {
            Name = name;
            Number = number;
            AccountType = accountType;
            ChildrenAccounts = childrenAccounts;
        }

        public string Name { get; }

        public int Number { get; }

        public AccountType AccountType { get; }

        public IEnumerable<AccountDto> ChildrenAccounts { get; }

    }
}