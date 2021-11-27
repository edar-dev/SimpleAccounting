using System;
using Accounting.Application.Domain.AccountPlan;
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
            _accountPlanItemRepository = accountPlanItemRepository ?? throw new ArgumentNullException(nameof(accountPlanItemRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public AccountPlanItemDto Create(CreateAccountPlanItemDto createAccountPlanItemDto)
        {
            var accountPlanItemToCreate = _mapper.Map<AccountPlanItem>(createAccountPlanItemDto);
            var accountPlanItem = _accountPlanItemRepository.Create(accountPlanItemToCreate);

            var createdAccountPlanItem = _mapper.Map<AccountPlanItemDto>(accountPlanItem);
            return createdAccountPlanItem;

        }
    }

}