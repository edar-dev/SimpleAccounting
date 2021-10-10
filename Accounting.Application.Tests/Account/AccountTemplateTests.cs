using System.Linq;
using Accounting.Application.Domain.Account;
using Accounting.Application.MappingProfileApplication;
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
        private readonly IAccountService _accountService;

        public AccountTemplateTests()
        {
            RedoDBEngineBuilder<AccountRepository, IAccountRepository> accountRepositoryBuilder = new();
            accountRepositoryBuilder.WithNoPersistence();
            RedoDBEngineBuilder<AccountTemplateRepository, IAccountTemplateRepository> accountTemplateRepositoryBuilder = new();
            accountTemplateRepositoryBuilder.WithNoPersistence();
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<AccountProfileApplication>());
            IMapper mapper = new Mapper(mapperConfig);
            _accountService = new AccountService(accountRepositoryBuilder.Build(),accountTemplateRepositoryBuilder.Build(), mapper);
        }

        [Fact]
        public void AccountTemplate_CanCreate()

        {
            // SETUP
            var cashAndFinancialAssetsAccount = GetCashAndFinancialAssetsAccount();

            var assetsAccount = new AccountTemplateDto("Assets", 1, AccountType.Debit, cashAndFinancialAssetsAccount);

            var balanceAccount = new AccountTemplateDto("Balance", 0, AccountType.None, assetsAccount);
            var newAccountTemplate = new ChartOfAccountTemplateDto("Test Account Template", "Test Account Template Desc",
                new[] { balanceAccount });
            // ACT
            var accountTemplateDto =  _accountService.CreateAccountTemplate(newAccountTemplate);

            // ASSERT
            accountTemplateDto.Name.Should().Be(newAccountTemplate.Name);
            accountTemplateDto.Description.Should().Be(newAccountTemplate.Description);
            accountTemplateDto.ChartOfAccounts.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            var balance = accountTemplateDto.ChartOfAccounts.ElementAt(0);
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

        private static AccountTemplateDto GetCashAndFinancialAssetsAccount()
        {
            var cashAndCashEquivalents = new AccountTemplateDto("Cash and Cash Equivalents", 1, AccountType.Debit);
            var financialAssetsInvestments =
                new AccountTemplateDto("Financial Assets (Investments)", 2, AccountType.Debit);
            var restrictedCashAndFinancialAssets =
                new AccountTemplateDto("Restricted Cash and Financial Assets", 3, AccountType.Debit);
            var additionalFinancialAssetsAndInvestments =
                new AccountTemplateDto("Additional Financial Assets and Investments", 4, AccountType.Debit);

            var cashAndFinancialAssetsAccount = new AccountTemplateDto("Cash And Financial Assets", 1,
                AccountType.Debit,
                new[]
                {
                    cashAndCashEquivalents,
                    financialAssetsInvestments,
                    restrictedCashAndFinancialAssets,
                    additionalFinancialAssetsAndInvestments
                });
            return cashAndFinancialAssetsAccount;
        }
    }
}