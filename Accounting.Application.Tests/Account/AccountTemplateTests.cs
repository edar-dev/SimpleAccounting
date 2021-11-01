using System.Linq;
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
    public class AccountTemplateTests
    {
        private readonly IAccountTemplateService _accountTemplateService;

        public AccountTemplateTests()
        {
            RedoDBEngineBuilder<AccountTemplateRepository, IAccountTemplateRepository> accountTemplateRepositoryBuilder = new();
            accountTemplateRepositoryBuilder.WithNoPersistence();
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<AccountProfileApplication>());
            IMapper mapper = new Mapper(mapperConfig);
            _accountTemplateService = new AccountTemplateService(accountTemplateRepositoryBuilder.Build(), mapper);
        }

        [Fact]
        public void AccountTemplate_CanCreate()

        {
            // SETUP
            AccountTestHelper.GetExampleChartOfAccountTemplate(out ChartOfAccountsTemplateDto newAccountTemplate,out AccountTemplateDto assetsAccount, out AccountTemplateDto balanceAccount, out AccountTemplateDto cashAndFinancialAssetsAccount);
            // ACT
            var accountTemplateDto =  _accountTemplateService.CreateAccountTemplate(newAccountTemplate);

            // ASSERT
            accountTemplateDto.Name.Should().Be(newAccountTemplate.Name);
            accountTemplateDto.Description.Should().Be(newAccountTemplate.Description);
            accountTemplateDto.Accounts.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            var balance = accountTemplateDto.Accounts.ElementAt(0);
            balance.Name.Should().Be(balanceAccount.Name);
            balance.Number.Should().Be(balanceAccount.Number);
            balance.Type.Should().Be(AccountType.Debit);
            balance.Id.Should().NotBeEmpty();
            balance.ChildrenAccount.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            var assets = balance.ChildrenAccount.ElementAt(0);
            assets.Name.Should().Be(assetsAccount.Name);
            assets.Number.Should().Be(assetsAccount.Number);
            assets.Type.Should().Be(AccountType.Debit);
            assets.Id.Should().NotBeEmpty();
            assets.ChildrenAccount.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            var cashAndFinancialAssets = assets.ChildrenAccount.ElementAt(0);
            cashAndFinancialAssets.Name.Should().Be(cashAndFinancialAssetsAccount.Name);
            cashAndFinancialAssets.Number.Should().Be(cashAndFinancialAssetsAccount.Number);
            cashAndFinancialAssets.Type.Should().Be(AccountType.Debit);
            cashAndFinancialAssets.Id.Should().NotBeEmpty();
            cashAndFinancialAssets.ChildrenAccount.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(4);
        }

    }
}