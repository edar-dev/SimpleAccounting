using System.Collections.Generic;

namespace Accounting.Application.Domain.Account
{
    public class ChartOfAccountTemplateDto : DtoBase
    {
        public ChartOfAccountTemplateDto(string name, string description,
            IEnumerable<AccountTemplateDto> chartOfAccounts)
        {
            Name = name;
            Description = description;
            ChartOfAccounts = chartOfAccounts;
        }

        public string Name { get; }
        public string Description { get; }
        public IEnumerable<AccountTemplateDto> ChartOfAccounts { get; }
    }
}