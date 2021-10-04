using System;

namespace Accounting.Persistence.Entity
{
    public class Account: EntityBase
    {
        public Account(string name, int number, AccountType type, Guid? parentAccountId)
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