using Accounting.API.ViewModels;
using Accounting.Application.Domain.Company;
using AutoMapper;

namespace Accounting.API.MappingProfilesApi
{
    public class CompanyProfileApi : Profile
    {
        public CompanyProfileApi()
        {
            CreateMap<CreateCompanyViewModel, CreateCompanyDto>();

        }
    }
}