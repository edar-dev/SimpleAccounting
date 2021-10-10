using System.Collections.Generic;

namespace Accounting.Persistence.Entity
{
    public class AccountTemplate: EntityBase
    {
        private readonly List<AccountTemplate> _childrenAccount = new();

        public AccountTemplate(string name, int number, AccountType type, AccountTemplate? childAccount = null)
        {
            Name = name;
            Number = number;
            Type = type;

            if (childAccount is not null)
            {
                _childrenAccount.Add(childAccount);
            }
        }

        public AccountTemplate(string name, int number, AccountType type,
            IEnumerable<AccountTemplate> childTemplateAccount)
        {
            Name = name;
            Number = number;
            Type = type;

            _childrenAccount.AddRange(childTemplateAccount);
        }

        public string Name { get; }

        public int Number { get; }

        public AccountType Type { get; }

        public IEnumerable<AccountTemplate> ChildrenAccount => _childrenAccount;
    }
}