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
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public AccountDto Create(CreateAccountDto createAccountDto)
        {
            var accountToCreate = _mapper.Map<Account>(createAccountDto);
            var account = _accountRepository.Create(accountToCreate);
            
            return Get(account.Id);
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
                accountDto.ParentAccount = Get(accountDto.ParentAccountId.Value);
            }
        }
    }
}