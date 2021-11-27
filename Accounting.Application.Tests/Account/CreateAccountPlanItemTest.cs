using System;
using Accounting.Application.Domain.AccountPlan;
using Accounting.Application.Domain.Company;
using Accounting.Application.MappingProfileApplication;
using Accounting.Application.Services;
using Accounting.Persistence;
using Accounting.Persistence.RedoDb;
using AutoMapper;
using BoCode.RedoDB.Builder;
using FluentAssertions;
using Xunit;

namespace Accounting.Application.Tests.Account
{
    public class CreateAccountPlanItemTest
    {
        private readonly IAccountPlanService _accountPlanService;

        public CreateAccountPlanItemTest()
        {
            RedoDBEngineBuilder<AccountPlanItemRespository, IAccountPlanItemRepository>
                accountPlanItemRepositoryBuilder = new();
            accountPlanItemRepositoryBuilder.WithNoPersistence();
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<AccountPlanItemProfileApplication>());
            IMapper mapper = new Mapper(mapperConfig);
            _accountPlanService = new AccountPlanService(accountPlanItemRepositoryBuilder.Build(), mapper);
        }

        [Fact]
        public void CreateAccountPlan()
        {
            //SETUP
            CreateAccountPlanItemDto createAccountPlanItemDto = new("1", "name",(int)AccountPlanItemType.None, Guid.Empty, null,null);
            //ACT
            var accountPlanItemDto = _accountPlanService.Create(createAccountPlanItemDto);

            //ASSERT
            accountPlanItemDto.Number.Should().Be(createAccountPlanItemDto.Number);
            accountPlanItemDto.AccountIdentity.Should().Be(createAccountPlanItemDto.AccountIdentity);
            accountPlanItemDto.CompanyId.Should().Be(createAccountPlanItemDto.CompanyId);
            accountPlanItemDto.ParentIdentity.Should().Be(createAccountPlanItemDto.ParentIdentity);
            accountPlanItemDto.AccountPlanItemType.Should().Be(createAccountPlanItemDto.AccountPlanItemType);
            accountPlanItemDto.Id.Should().NotBe(Guid.Empty);
        }
    }
}