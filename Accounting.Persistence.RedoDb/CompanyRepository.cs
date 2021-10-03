using System.Collections.Generic;
using Accounting.Persistence.Entity;
using BoCode.RedoDB.RedoableData;

namespace Accounting.Persistence.RedoDb
{
    public class CompanyRepository : ICompanyRepository, IDependsOnRedoableGuid
    {
        private ICollection<Company> _companies = new List<Company>();
        private IRedoableGuid _redoableGuid;

        public Company Create(Company company)
        {
            company.Id = _redoableGuid.New();
            
            _companies.Add(company);

            return company;
        }

        public void SetRedoableGuid(IRedoableGuid redoableGuid)
        {
            _redoableGuid = redoableGuid;
        }
    }
}