using Accounting.Application.MappingProfileApplication;
using Accounting.Persistence;
using Accounting.Persistence.RedoDb;
using AutoMapper;
using BoCode.RedoDB.Builder;

namespace Accounting.Application.Tests.Account
{
    public class AccountTemplateTests
    {
        private readonly IAccountService _accountService;

        public AccountTemplateTests()
        {
            RedoDBEngineBuilder<AccountRepository, IAccountRepository> accountRepositoryBuilder = new();
            accountRepositoryBuilder.WithNoPersistence();
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<AccountProfileApplication>());
            IMapper mapper = new Mapper(mapperConfig);
            _accountService = new AccountService(accountRepositoryBuilder.Build(), mapper);
        }

        public void AccountTemplate_CanCreate()
        {
            // SETUP
            
            // ACT
            
            // ASSERT
        }
    }
}