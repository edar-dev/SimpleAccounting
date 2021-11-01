using System;
using System.Collections.Generic;

namespace Accounting.Application.Domain.Account
{
    public class ChartOfAccountsDto : DtoBase
    {
        public ChartOfAccountsDto(string name,
            string description,
            DateTime openingDate,
            DateTime closingDate,
            IEnumerable<AccountDto> accounts,
            Guid? referenceId)
        {
            Name = name;
            Description = description;
            Accounts = accounts;
            OpeningDate = openingDate;
            ClosingDate = closingDate;
            ReferenceId = referenceId;
        }

        public string Name { get; }
        public string Description { get; }
        public IEnumerable<AccountDto> Accounts { get; }

        public DateTime OpeningDate { get; }
        public DateTime ClosingDate { get; }

        public Guid? ReferenceId { get; }
    }
}