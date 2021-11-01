using System.Collections.Generic;
using Accounting.Application.Domain.Account;
using Accounting.Persistence.Entity;
using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using AccountTypeEntity = Accounting.Persistence.Entity.AccountType;
using AccountTypeDto = Accounting.Application.Domain.Account.AccountType;

namespace Accounting.Application.MappingProfileApplication
{
    public class AccountProfileApplication : Profile
    {
        public AccountProfileApplication()
        {
            CreateMap<CreateAccountDto, Account>();
            
            CreateMap<AccountTypeEntity, AccountTypeDto>().ConvertUsingEnumMapping().ReverseMap();

            CreateMap<Account, AccountDto>();
            
            CreateMap<AccountDto, Account>();
            
            CreateMap<ChartOfAccountsTemplateDto,ChartOfAccountTemplate>().ReverseMap();
            
            CreateMap<AccountTemplateDto,AccountTemplate>().ReverseMap();

            CreateMap<ChartOfAccounts, ChartOfAccountsDto>().ReverseMap();
        }
    }
}