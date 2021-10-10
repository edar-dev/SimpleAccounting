using System.Collections.Generic;

#nullable enable
namespace Accounting.Application.Domain.Account
{
    public class AccountTemplateDto : DtoBase
    {
        
        private readonly List<AccountTemplateDto> _childrenAccount = new();

        public AccountTemplateDto(string name, int number, AccountType type, AccountTemplateDto? childAccount = null)
        {
            Name = name;
            Number = number;
            Type = type;

            if (childAccount is not null)
            {
                _childrenAccount.Add(childAccount);
            }
        }

        public AccountTemplateDto(string name, int number, AccountType type,
            IEnumerable<AccountTemplateDto> childTemplateAccount)
        {
            Name = name;
            Number = number;
            Type = type;

            _childrenAccount.AddRange(childTemplateAccount);
        }

        public string Name { get; }

        public int Number { get; }

        public AccountType Type { get; }

        public IEnumerable<AccountTemplateDto> ChildrenAccount => _childrenAccount;
    }
}