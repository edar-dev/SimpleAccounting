using System;
using Accounting.Application.Domain.Account;

namespace Accounting.ViewModels
{
    public class CreateAccountViewModel
    {
        public CreateAccountViewModel(string name, int number, AccountType type, Guid? parentAccountId)
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