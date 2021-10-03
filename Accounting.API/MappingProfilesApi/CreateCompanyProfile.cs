using Accounting.Application.Domain.Company;
using Accounting.ViewModels;
using AutoMapper;
namespace Accounting.MappingProfilesApi
{
    public class CreateCompanyProfile : Profile
    {
        public CreateCompanyProfile()
        {
            CreateMap<CreateCompanyViewModel, CreateCompanyDto>();

        }
    }
}