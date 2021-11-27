using Accounting.Application.Domain.AccountPlan;

namespace Accounting.Application.Services
{
    public interface IAccountPlanService
    {
        AccountPlanItemDto Create(CreateAccountPlanItemDto createAccountPlanItemDto);
    }
}