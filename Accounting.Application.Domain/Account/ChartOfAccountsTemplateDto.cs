using System.Collections.Generic;

namespace Accounting.Application.Domain.Account
{
    public class ChartOfAccountsTemplateDto : DtoBase
    {
        public ChartOfAccountsTemplateDto(string name, string description,
            IEnumerable<AccountTemplateDto> accounts)
        {
            Name = name;
            Description = description;
            Accounts = accounts;
        }

        public string Name { get; }
        public string Description { get; }
        public IEnumerable<AccountTemplateDto> Accounts { get; }
    }
}