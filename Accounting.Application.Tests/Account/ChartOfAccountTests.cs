using System;
using System.Linq;
using Accounting.Application.Coordinators;
using Accounting.Application.Domain.Account;
using Accounting.Application.MappingProfileApplication;
using Accounting.Application.Services;
using Accounting.Persistence;
using Accounting.Persistence.RedoDb;
using AutoMapper;
using BoCode.RedoDB.Builder;
using FluentAssertions;
using Xunit;

namespace Accounting.Application.Tests.Account
{
    public class ChartOfAccountTests
    {
        private readonly IAccountCoordinator _accountCoordinator;
        private readonly IAccountTemplateService _accountTemplateService;
        private readonly IAccountService _accountService;

        public ChartOfAccountTests()
        {
            RedoDBEngineBuilder<AccountRepository, IAccountRepository> accountRepositoryBuilder = new();
            accountRepositoryBuilder.WithNoPersistence();
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<AccountProfileApplication>());
            RedoDBEngineBuilder<AccountTemplateRepository, IAccountTemplateRepository> accountTemplateRepositoryBuilder = new();
            accountTemplateRepositoryBuilder.WithNoPersistence();
            IMapper mapper = new Mapper(mapperConfig);
            IAccountRepository accountRepository = accountRepositoryBuilder.Build();
            IAccountTemplateRepository accountTemplateRepository = accountTemplateRepositoryBuilder.Build();

            _accountTemplateService = new AccountTemplateService(accountTemplateRepository, mapper);
            _accountService = new AccountService(accountRepository, mapper);
            _accountCoordinator = new AccountCoordinator(accountRepository, accountTemplateRepository, mapper);
        }
        
        [Fact]
        public void CreateChartOfAccountFromTemplate()
        {
            AccountTestHelper.GetExampleChartOfAccountTemplate(out ChartOfAccountsTemplateDto newAccountTemplate,out AccountTemplateDto _, out AccountTemplateDto _, out AccountTemplateDto _);

            var coat = _accountTemplateService.CreateAccountTemplate(newAccountTemplate);

            var openingDate = DateTime.UtcNow;
            Guid coaId = _accountCoordinator.CreateChartOfAccountsFromTemplate(coat.Id, openingDate, openingDate.AddMonths(4), null);

            ChartOfAccountsDto coaDto = _accountService.GetChartOfAccounts(coaId);

            coaDto.Name.Should().Be(coaDto.Name);
            coaDto.Description.Should().Be(coaDto.Description);
            coaDto.OpeningDate.Should().Be(openingDate);
            coaDto.ClosingDate.Should().Be(openingDate.AddMonths(4));
            coaDto.ReferenceId.Should().BeNull();
            coaDto.Accounts.Should().NotBeNullOrEmpty();
        }
        
        [Fact]
        public void CreateChartOfAccount()
        {
            var openingDate = DateTime.UtcNow;
            AccountTestHelper.GetExampleChartOfAccountDto(out ChartOfAccountsDto newAccountTemplate,out AccountDto assetsAccount, out AccountDto balanceAccount, out AccountDto _, openingDate, openingDate.AddMonths(4));

            Guid coaId = _accountService.CreateChartOfAccounts(newAccountTemplate);

            var coaDto = _accountService.GetChartOfAccounts(coaId);

            coaDto.Name.Should().Be(coaDto.Name);
            coaDto.Description.Should().Be(coaDto.Description);
            coaDto.OpeningDate.Should().Be(openingDate);
            coaDto.ClosingDate.Should().Be(openingDate.AddMonths(4));
            coaDto.ReferenceId.Should().BeNull();
            coaDto.Accounts.Should().NotBeNullOrEmpty();

            var balanceAccountDto = coaDto.Accounts.Single();
            balanceAccountDto.Name.Should().Be(balanceAccount.Name);
        }

    }
}