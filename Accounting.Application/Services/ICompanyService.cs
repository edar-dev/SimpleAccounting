using Accounting.Application.Domain.Company;

namespace Accounting.Application.Services
{
    public interface ICompanyService
    {
        CompanyDto Create(CreateCompanyDto createCompanyDto);
    }
}