using Accounting.Application.Domain.Company;
using Accounting.Persistence.Entity;
using AutoMapper;

namespace Accounting.Application.MappingProfileApplication
{
    public class CompanyProfileApplication : Profile
    {
        public CompanyProfileApplication()
        {
            CreateMap<CreateCompanyDto, Company>();
            
            CreateMap<Company,CompanyDto>();

        }
    }
}