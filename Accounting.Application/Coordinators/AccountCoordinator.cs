using System;
using System.Collections.Generic;
using Accounting.Application.Exception;
using Accounting.Persistence;
using Accounting.Persistence.Entity;
using AutoMapper;

namespace Accounting.Application.Coordinators
{
    public class AccountCoordinator : IAccountCoordinator
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountTemplateRepository _accountTemplateRepository;
        private readonly IMapper _mapper;

        public AccountCoordinator(IAccountRepository accountRepository,
            IAccountTemplateRepository accountTemplateRepository, IMapper mapper)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _accountTemplateRepository = accountTemplateRepository ??
                                         throw new ArgumentNullException(nameof(accountTemplateRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        
        public Guid CreateChartOfAccountsFromTemplate(Guid templateId, DateTime openingDate, DateTime closingDate, Guid? referenceId)
        {
            if (openingDate > closingDate)
            {
                throw new ExceptionWrapper($"{nameof(AccountCoordinator)}_InvalidDates",new InvalidOperationException("The closing date must be greater then than the opening date"));
            }
            
            ChartOfAccountTemplate coaTemplate = _accountTemplateRepository.Get(templateId);

            IEnumerable<Account> coaAccounts = ConvertToRealAccount(coaTemplate.Accounts);

            var coa = new ChartOfAccounts(coaTemplate.Name, coaTemplate.Description, openingDate, closingDate,
                coaAccounts, referenceId);

            var coaId = _accountRepository.SaveChartOfAccount(coa);
            
            return  coaId;
        }

        private IEnumerable<Account> ConvertToRealAccount(IEnumerable<AccountTemplate> accounts)
        {
            foreach (var account in accounts)
            {
                yield return new Account(account.Name,
                    account.Number,
                    account.Type,
                    ConvertToRealAccount(account.ChildrenAccount));
            }
        }
    }
}