using System;

namespace Accounting.Application.Domain.AccountPlan
{
    public class AccountPlanItemDto : DtoBase
    {
        public AccountPlanItemDto(string number, string name, int accountPlanItemType,
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