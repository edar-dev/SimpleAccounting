using System;

namespace Accounting.Application.Domain.Account
{
    public class CreateAccountDto
    {
        public CreateAccountDto(string name, int number, AccountType type, Guid? parentAccountId)
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
    }
}