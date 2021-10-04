using Accounting.Application.Domain.Company;

namespace Accounting.Application
{
    public interface ICompanyService
    {
        CompanyDto Create(CreateCompanyDto createCompanyDto);
    }
}