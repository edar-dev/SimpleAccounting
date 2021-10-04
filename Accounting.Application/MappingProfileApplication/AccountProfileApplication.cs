using Accounting.Application.Domain.Account;
using Accounting.Persistence.Entity;
using AutoMapper;

namespace Accounting.Application.MappingProfileApplication
{
    public class AccountProfileApplication : Profile
    {
        public AccountProfileApplication()
        {
            CreateMap<CreateAccountDto, Account>();
            
            CreateMap<Account,AccountDto>();
        }
    }
}