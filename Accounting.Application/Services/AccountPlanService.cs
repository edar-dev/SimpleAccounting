using System;
using Accounting.Application.Domain.AccountPlan;
using Accounting.Application.Domain.Exceptions;
using Accounting.Persistence;
using Accounting.Persistence.Entity;
using AutoMapper;

namespace Accounting.Application.Services
{
    public class AccountPlanService : IAccountPlanService
    {
        private readonly IAccountPlanItemRepository _accountPlanItemRepository;
        private readonly IMapper _mapper;

        public AccountPlanService(IAccountPlanItemRepository accountPlanItemRepository, IMapper mapper)
        {
            _accountPlanItemRepository = accountPlanItemRepository ??
                                         throw new ArgumentNullException(nameof(accountPlanItemRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public AccountPlanItemDto Create(CreateAccountPlanItemDto createAccountPlanItemDto)
        {
            var accountPlanItemToCreate = _mapper.Map<AccountPlanItem>(createAccountPlanItemDto);

            if (accountPlanItemToCreate.ParentIdentity.HasValue &&
                accountPlanItemToCreate.ParentIdentity.Value != Guid.Empty)
            {
                var parentAccountPlanItemExists = _accountPlanItemRepository.Exists(accountPlanItemToCreate.ParentIdentity.Value);
                if (!parentAccountPlanItemExists)
                {
                    throw new AccountingApplicationException("Parent account plan item not found", ApplicationExceptionErrorCode.AccountPlanItemInvalidParent);
                }
            }

            var accountPlanItem = _accountPlanItemRepository.Create(accountPlanItemToCreate);

            var createdAccountPlanItem = _mapper.Map<AccountPlanItemDto>(accountPlanItem);
            return createdAccountPlanItem;
        }
    }
}