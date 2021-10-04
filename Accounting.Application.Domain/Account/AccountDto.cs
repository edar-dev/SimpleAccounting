#nullable enable
using System;

namespace Accounting.Application.Domain.Account
{
    public class AccountDto : DTOBase
    {
        public AccountDto(string name, int number, AccountType type, Guid? parentAccountId)
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

        public AccountDto? ParentAccount { get; set; }

        public string FullNumber
        {
            get
            {
                return string.Empty;
            }
        }
    }
}