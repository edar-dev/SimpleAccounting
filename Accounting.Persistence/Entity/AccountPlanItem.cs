using System;

namespace Accounting.Persistence.Entity
{
    public class AccountPlanItem : EntityBase
    {
        public AccountPlanItem(string number, string name, int accountPlanItemType,
            Guid companyId, Guid? accountIdentity, Guid? parentIdentity)
        {
            Number = number;
            Name = name;
            CompanyId = companyId;
            AccountIdentity = accountIdentity;
            AccountPlanItemType = accountPlanItemType;
            ParentIdentity = parentIdentity;
        }

        public string Number { get; set; }

        public string Name { get; set; }

        public Guid? CompanyId { get; set; }

        public Guid? AccountIdentity { get; set; }

        public int AccountPlanItemType { get; set; }

        public Guid? ParentIdentity { get; set; }
    }
}