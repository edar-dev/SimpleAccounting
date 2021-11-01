using System.Collections.Generic;

namespace Accounting.Persistence.Entity
{
    public class ChartOfAccountTemplate : EntityBase
    {
        public ChartOfAccountTemplate(string name, string description,
            IEnumerable<AccountTemplate> accounts)
        {
            Name = name;
            Description = description;
            Accounts = accounts;
        }

        public string Name { get; }
        public string Description { get; }
        public IEnumerable<AccountTemplate> Accounts { get; }
    }
}