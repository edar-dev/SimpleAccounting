using System;
using Accounting.Application.Domain.Account;
using Accounting.Persistence;
using Accounting.Persistence.Entity;
using AutoMapper;

namespace Accounting.Application
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountTemplateRepository _accountTemplateRepository;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository accountRepository,
            IAccountTemplateRepository accountTemplateRepository,
            IMapper mapper)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _accountTemplateRepository = accountTemplateRepository ?? throw new ArgumentNullException(nameof(accountTemplateRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public AccountDto Create(CreateAccountDto createAccountDto)
        {
            var accountToCreate = _mapper.Map<Account>(createAccountDto);
            var account = _accountRepository.Create(accountToCreate);

            return Get(account.Id);
        }

        public ChartOfAccountTemplateDto CreateAccountTemplate(ChartOfAccountTemplateDto newChartOfAccountTemplate)
        {
            var chartOfAccountTemplateToCreate = _mapper.Map<ChartOfAccountTemplate>(newChartOfAccountTemplate);

            Guid chartOfAccountTemplateId = _accountTemplateRepository.Create(chartOfAccountTemplateToCreate);

            return GetChartOfAccountTemplate(chartOfAccountTemplateId);
        }

        private ChartOfAccountTemplateDto GetChartOfAccountTemplate(Guid chartOfAccountTemplateId)
        {
            throw new NotImplementedException();
        }

        private AccountDto Get(Guid accountId)
        {
            var account = _accountRepository.Get(accountId);

            var accountDto = _mapper.Map<AccountDto>(account);

            PopulateParentAccountRecursively(accountDto);

            return accountDto;
        }

        private void PopulateParentAccountRecursively(AccountDto accountDto)
        {
            if (accountDto.ParentAccountId.HasValue)
            {
                accountDto.ParentParentAccount = Get(accountDto.ParentAccountId.Value);
            }
        }
    }
}