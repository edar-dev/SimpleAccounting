using Microsoft.Extensions.DependencyInjection;
using BoCode.RedoDB.DependencyInjection;

namespace Accounting.Persistence.RedoDb
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigurePersistenceService(this IServiceCollection services)
        {
            services.AddRedoDB<ICompanyRepository, CompanyRepository>(ServiceLifetime.Singleton,(redo) => redo.WithJsonAdapters("d://data").Build());
        }
    }
}