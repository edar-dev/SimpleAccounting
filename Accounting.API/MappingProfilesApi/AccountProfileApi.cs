using Accounting.API.ViewModels;
using Accounting.Application.Domain.Account;
using AutoMapper;

namespace Accounting.API.MappingProfilesApi
{
    public class AccountProfileApi : Profile
    {
        public AccountProfileApi()
        {
            CreateMap<CreateAccountViewModel, CreateAccountDto>();

        }
    }
}