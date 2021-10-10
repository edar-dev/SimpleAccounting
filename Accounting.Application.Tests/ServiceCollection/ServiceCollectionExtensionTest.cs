using Accounting.API;
using Accounting.Application.MappingProfileApplication;
using Accounting.Persistence;
using Accounting.Persistence.RedoDb;
using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;
using IMapper = AutoMapper.IMapper;

namespace Accounting.Application.Tests.ServiceCollection
{
    public class ServiceCollectionExtensionTest
    {
        [Fact]
        public void RedoDbServiceCollectionExtensionsTestCompanyRepository()
        {
            // SETUP
            var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();

            services.ConfigurePersistenceService();

            var provider = services.BuildServiceProvider();

            // ACT
            var companyRepository = provider.GetRequiredService<ICompanyRepository>();

            //ASSERT
            companyRepository.Should().NotBeNull();
        }
        
        [Fact]
        public void RedoDbServiceCollectionExtensionsTestAccountRepository()
        {
            // SETUP
            var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();

            services.ConfigurePersistenceService();

            var provider = services.BuildServiceProvider();

            // ACT
            var accountRepository = provider.GetRequiredService<IAccountRepository>();

            //ASSERT
            accountRepository.Should().NotBeNull();
        }
        
        [Fact]
        public void ApplicationServiceCollectionExtensionsTestCompanyService()
        {
            // SETUP
            var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();

            services.AddSingleton(new Mock<ICompanyRepository>().Object);
            
            var mappingConfig = new MapperConfiguration(mc => {});
            services.AddScoped<IMapper>(serviceProvider => new Mapper(mappingConfig));
            services.ConfigureApplicationService();

            var provider = services.BuildServiceProvider();

            // ACT
            var companyService = provider.GetRequiredService<ICompanyService>();

            //ASSERT
            companyService.Should().NotBeNull();
        }
        
        [Fact]
        public void ApplicationServiceCollectionExtensionsTestAccountService()
        {
            // SETUP
            var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
            
            services.AddSingleton(new Mock<IAccountRepository>().Object);
            services.AddSingleton(new Mock<IAccountTemplateRepository>().Object);

            var mappingConfig = new MapperConfiguration(mc => {});
            services.AddScoped<IMapper>(serviceProvider => new Mapper(mappingConfig));
            services.ConfigureApplicationService();

            var provider = services.BuildServiceProvider();

            // ACT
            var accountService = provider.GetRequiredService<IAccountService>();

            //ASSERT
            accountService.Should().NotBeNull();
        }
        
        [Fact]
        public void StartupRegistration()
        {
            // SETUP

            Mock<IConfiguration> configurationStub = new();
            
            IServiceCollection services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
            var target = new Startup(configurationStub.Object);

            // ACT
            target.ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();
            
            //ASSERT
            serviceProvider.GetService<ICompanyService>().Should().NotBeNull();
            serviceProvider.GetService<IAccountService>().Should().NotBeNull();

            target.Configuration.Should().Be(configurationStub.Object);

        }
    }
}