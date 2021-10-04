using Accounting.Application.Domain.Account;
using Accounting.ViewModels;
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