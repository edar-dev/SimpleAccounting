using Accounting.Persistence.Entity;

namespace Accounting.Persistence
{
    public interface ICompanyRepository
    {
        Company Create(Company company);
    }
}