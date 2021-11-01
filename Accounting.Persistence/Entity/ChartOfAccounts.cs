using System;
using System.Collections.Generic;

namespace Accounting.Persistence.Entity
{
    public class ChartOfAccounts: EntityBase
    {
        public ChartOfAccounts(string name,
            string description,
            DateTime openingDate,
            DateTime closingDate,
            IEnumerable<Account> accounts,
            Guid? referenceId = null)
        {
            Name = name;
            Description = description;
            OpeningDate = openingDate;
            ClosingDate = closingDate;
            Accounts = accounts;
            ReferenceId = referenceId;
        }
        
        public string Name { get; }
        public string Description { get; }
        public DateTime OpeningDate { get; }
        public DateTime ClosingDate { get; }
        public IEnumerable<Account> Accounts { get; }
        public Guid? ReferenceId { get; }
    }
}