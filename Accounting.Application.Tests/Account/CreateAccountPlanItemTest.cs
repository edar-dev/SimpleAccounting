using System;
using Accounting.Application.Domain.AccountPlan;
using Accounting.Application.Domain.Company;
using Accounting.Application.Domain.Exceptions;
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
        public void CreateAccountPlanWithoutParentAccount()
        {
            //SETUP
            CreateAccountPlanItemDto createAccountPlanItemDto =
                new("1", "name", (int)AccountPlanItemType.None, Guid.Empty, null, null);
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

        [Fact]
        public void CreateAccountPlanWithExistingParentAccount()
        {
            //SETUP
            CreateAccountPlanItemDto createParentAccountPlanItemDto =
                new("1", "name", (int)AccountPlanItemType.None, Guid.Empty, null, null);
            var parentAccountPlanItemDto = _accountPlanService.Create(createParentAccountPlanItemDto);

            CreateAccountPlanItemDto createChildAccountPlanItemDto = new("1", "name", (int)AccountPlanItemType.None,
                Guid.Empty, null, parentAccountPlanItemDto.Id);

            //ACT
            var accountPlanItemDto = _accountPlanService.Create(createChildAccountPlanItemDto);

            //ASSERT
            accountPlanItemDto.Number.Should().Be(createChildAccountPlanItemDto.Number);
            accountPlanItemDto.AccountIdentity.Should().Be(createChildAccountPlanItemDto.AccountIdentity);
            accountPlanItemDto.CompanyId.Should().Be(createChildAccountPlanItemDto.CompanyId);
            accountPlanItemDto.ParentIdentity.Should().Be(createChildAccountPlanItemDto.ParentIdentity);
            accountPlanItemDto.AccountPlanItemType.Should().Be(createChildAccountPlanItemDto.AccountPlanItemType);
            accountPlanItemDto.Id.Should().NotBe(Guid.Empty);
        }

        [Fact]
        public void CreateAccountPlanWithNotExistingParentAccount()
        {
            //SETUP
            CreateAccountPlanItemDto createParentAccountPlanItemDto =
                new("1", "name", (int)AccountPlanItemType.None, Guid.Empty, null, null);
            var parentAccountPlanItemDto = _accountPlanService.Create(createParentAccountPlanItemDto);

            CreateAccountPlanItemDto createChildAccountPlanItemDto = new("2", "name", (int)AccountPlanItemType.None,
                Guid.Empty, null, Guid.NewGuid());

            //ACT
            Action act = () => _accountPlanService.Create(createChildAccountPlanItemDto);

            //ASSERT
            act.Should().Throw<AccountingApplicationException>().Where(e => e.ErrorCode == ApplicationExceptionErrorCode.AccountPlanItemInvalidParent);
        }
    }
}