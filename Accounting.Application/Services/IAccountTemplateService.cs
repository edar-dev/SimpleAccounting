using Accounting.Application.Domain.Account;

namespace Accounting.Application.Services
{
    public interface IAccountTemplateService
    {
         ChartOfAccountsTemplateDto CreateAccountTemplate(ChartOfAccountsTemplateDto newChartOfAccountsTemplate);
    }
}