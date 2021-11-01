using System;
using Accounting.Application.Domain.Account;
using Accounting.Persistence;
using Accounting.Persistence.Entity;
using AutoMapper;

namespace Accounting.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository accountRepository,
            IMapper mapper)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public ChartOfAccountsDto GetChartOfAccounts(Guid chartOfAccountId)
        {
            ChartOfAccounts coa = _accountRepository.GetChartOfAccount(chartOfAccountId);

            var coaDto = _mapper.Map<ChartOfAccounts, ChartOfAccountsDto>(coa);

            return coaDto;
        }

        public Guid CreateChartOfAccounts(ChartOfAccountsDto chartOfAccountsDto)
        {
            var coa = _mapper.Map<ChartOfAccounts>(chartOfAccountsDto);
            var  coaId = _accountRepository.SaveChartOfAccount(coa);
            return coaId;
        }
    }
}