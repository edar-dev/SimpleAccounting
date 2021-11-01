using System;
using System.Linq;
using Accounting.Application.Domain.Account;

namespace Accounting.Application.Tests.Account
{
    public static class AccountTestHelper
    {
        public static void GetExampleChartOfAccountTemplate(out ChartOfAccountsTemplateDto newAccountsTemplate,
            out AccountTemplateDto assetsAccount,
            out AccountTemplateDto balanceAccount, out AccountTemplateDto cashAndFinancialAssetsAccount)
        {
            cashAndFinancialAssetsAccount = GetCashAndFinancialAssetsAccountTemplate();

            assetsAccount = new AccountTemplateDto("Assets", 1, AccountType.Debit, cashAndFinancialAssetsAccount);

            balanceAccount = new AccountTemplateDto("Balance", 0, AccountType.Debit, assetsAccount);
            newAccountsTemplate = new ChartOfAccountsTemplateDto("Test Account Template", "Test Account Template Desc",
                new[] { balanceAccount });
        }

        public static void GetExampleChartOfAccountDto(out ChartOfAccountsDto newAccountsTemplate,
            out AccountDto assetsAccount,
            out AccountDto balanceAccount, out AccountDto cashAndFinancialAssetsAccount, DateTime openingDate,
            DateTime closingDate)
        {
            cashAndFinancialAssetsAccount = GetCashAndFinancialAssetsAccount();

            assetsAccount = new AccountDto("Assets", 1, AccountType.Debit, new[] { cashAndFinancialAssetsAccount });

            balanceAccount = new AccountDto("Balance", 0, AccountType.None, new[] { assetsAccount });
            newAccountsTemplate = new ChartOfAccountsDto("Test Account Template", "Test Account Template Desc",
                openingDate, closingDate,
                new[] { balanceAccount }, null);
        }


        private static AccountTemplateDto GetCashAndFinancialAssetsAccountTemplate()
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

        private static AccountDto GetCashAndFinancialAssetsAccount()
        {
            var cashAndCashEquivalents = new AccountDto("Cash and Cash Equivalents", 1, AccountType.Debit,
                Enumerable.Empty<AccountDto>());
            var financialAssetsInvestments =
                new AccountDto("Financial Assets (Investments)", 2, AccountType.Debit, Enumerable.Empty<AccountDto>());
            var restrictedCashAndFinancialAssets =
                new AccountDto("Restricted Cash and Financial Assets", 3, AccountType.Debit,
                    Enumerable.Empty<AccountDto>());
            var additionalFinancialAssetsAndInvestments =
                new AccountDto("Additional Financial Assets and Investments", 4, AccountType.Debit,
                    Enumerable.Empty<AccountDto>());

            var cashAndFinancialAssetsAccount = new AccountDto("Cash And Financial Assets", 1,
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