using System;
using Accounting.Application.Domain.Company;
using Accounting.Application.MappingProfileApplication;
using Accounting.Persistence;
using Accounting.Persistence.RedoDb;
using AutoMapper;
using BoCode.RedoDB.Builder;
using FluentAssertions;
using Xunit;

namespace Accounting.Application.Tests.Company
{
    public class CreateCompanyTest
    {
        private readonly ICompanyService _companyService;

        public CreateCompanyTest()
        {
            RedoDBEngineBuilder<CompanyRepository, ICompanyRepository> companyRepositoryBuilder = new();
            companyRepositoryBuilder.WithNoPersistence();
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<CompanyProfileApplication>());
            IMapper mapper = new Mapper(mapperConfig);
            _companyService = new CompanyService(companyRepositoryBuilder.Build(), mapper);
        }

        [Fact]
        public void CreateCompany()
        {
            //SETUP

            CreateCompanyDto createCompanyDto = new("testCompany");

            //ACT
            var companyDto = _companyService.Create(createCompanyDto);

            //ASSERT
            companyDto.Name.Should().Be(createCompanyDto.Name);
            companyDto.Id.Should().NotBe(Guid.Empty);

        }
    }
}