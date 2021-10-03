using Accounting.Application.Domain.Company;
using Accounting.ViewModels;
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