using Accounting.Application.Domain.AccountPlan;
using Accounting.Persistence.Entity;
using AutoMapper;

namespace Accounting.Application.MappingProfileApplication
{
    public class AccountPlanItemProfileApplication : Profile
    {
        public AccountPlanItemProfileApplication()
        {
            CreateMap<CreateAccountPlanItemDto, AccountPlanItem>();
            
            CreateMap<AccountPlanItem,AccountPlanItemDto>();

        }
    }
}