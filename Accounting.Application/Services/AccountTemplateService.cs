using System;
using Accounting.Application.Domain.Account;
using Accounting.Persistence;
using Accounting.Persistence.Entity;
using AutoMapper;

namespace Accounting.Application.Services
{
    public class AccountTemplateService : IAccountTemplateService
    {
        private readonly IAccountTemplateRepository _accountTemplateRepository;
        private readonly IMapper _mapper;

        public AccountTemplateService(IAccountTemplateRepository accountTemplateRepository,
            IMapper mapper)
        {
            _accountTemplateRepository = accountTemplateRepository ?? throw new ArgumentNullException(nameof(accountTemplateRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public ChartOfAccountsTemplateDto CreateAccountTemplate(ChartOfAccountsTemplateDto newChartOfAccountsTemplate)
        {
            var chartOfAccountTemplateToCreate = _mapper.Map<ChartOfAccountTemplate>(newChartOfAccountsTemplate);

            Guid chartOfAccountTemplateId = _accountTemplateRepository.Create(chartOfAccountTemplateToCreate);

            return GetChartOfAccountTemplate(chartOfAccountTemplateId);
        }

        private ChartOfAccountsTemplateDto GetChartOfAccountTemplate(Guid chartOfAccountTemplateId)
        {
            var template =  _accountTemplateRepository.Get(chartOfAccountTemplateId);

            return _mapper.Map<ChartOfAccountsTemplateDto>(template);
        }

    }
}