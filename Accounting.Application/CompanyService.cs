using System;
using Accounting.Application.Domain.Company;
using Accounting.Persistence;
using Accounting.Persistence.Entity;
using AutoMapper;

namespace Accounting.Application
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public CompanyDto CreateNewCompany(CreateCompanyDto createCompanyDto)
        {
            var companyToCreate = _mapper.Map<Company>(createCompanyDto);
            var company = _companyRepository.Create(companyToCreate);

            var createdCompany = _mapper.Map<CompanyDto>(company);
            return createdCompany;
        }
    }
}