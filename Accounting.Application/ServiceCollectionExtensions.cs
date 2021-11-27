using Accounting.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Accounting.Application
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureApplicationService(this IServiceCollection services)
        {
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IAccountPlanService, AccountPlanService>();
        }
    }
}