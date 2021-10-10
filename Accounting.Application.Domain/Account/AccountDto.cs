#nullable enable
using System;

namespace Accounting.Application.Domain.Account
{
    public class AccountDto : DtoBase
    {
        public AccountDto(string name, int number, AccountType type, AccountDto parentAccountDto) : this(name, number,
            type, parentAccountDto.Id)
        {
            ParentParentAccount = parentAccountDto;
        }

        public AccountDto(string name, int number, AccountType type, Guid? parentAccountId = null)
        {
            Name = name;
            Number = number;
            Type = type;
            ParentAccountId = parentAccountId;
        }

        public string Name { get; set; }

        public int Number { get; set; }

        public AccountType Type { get; set; }

        public Guid? ParentAccountId { get; set; }

        public AccountDto? ParentParentAccount { get; set; }

        public string FullNumber => ParentParentAccount is not null
            ? string.Concat(ParentParentAccount.FullNumber, ".", Number)
            : Number.ToString();
    }
}