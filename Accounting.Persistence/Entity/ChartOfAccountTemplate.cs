using System;
using System.Collections.Generic;

namespace Accounting.Persistence.Entity
{
    public class ChartOfAccountTemplate: EntityBase
    {
        public ChartOfAccountTemplate(string name, string description,
            IEnumerable<AccountTemplate> chartOfAccounts)
        {
            Name = name;
            Description = description;
            ChartOfAccounts = chartOfAccounts;
        }

        public string Name { get; }
        public string Description { get; }
        public IEnumerable<AccountTemplate> ChartOfAccounts { get; }    }
}